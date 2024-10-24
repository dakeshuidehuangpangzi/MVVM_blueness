using CommunicationComponent;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Windows.Input;

public delegate void OrderEventHandler(MQTTClient sender, MessageReceivedArg e);

public  class MQTTClient
{
    #region 属性
    /// <summary>名称</summary>
    public string Name { get; set; }
    /// <summary>名称</summary>
    public string ClientID { get; set; } = Guid.NewGuid().ToString();
    /// <summary>用户名</summary>
    public string UserName { get; set; } = "admin";
    /// <summary>密码</summary>
    public string UserPassWord { get; set; } = "123456";
    /// <summary>生存确认</summary>
    public uint KeepAlive { get; set; }
    /// <summary>清除状态</summary>
    public bool  CleanStart { get; set; }
    public bool IsConnected { get; set; }

    public int Port { get; set; } = 1883;
    public string Host { get; set; } = "127.0.0.1";
    /// <summary>订阅主题集合</summary>
    public List<string> listTopic { get; set; } = new ();
    private IMqttClient mqttClient;

    #endregion

    #region 调用方法
    public ICommand ShowAxisDialogCommand { get; set; }
    #endregion

    #region Public Events
    public event EventHandler<MessageReceivedArg> MessageReceived = delegate { };
    public event EventHandler<ErrMessageArg> OneErrmessage = delegate { };
    public event EventHandler<bool> Connected = delegate { };
    public event EventHandler<bool> DisConnected = delegate { };
    #endregion

    #region TestEvents
    private OrderEventHandler _orderEventHandler;
    //public OrderEventHandler orderInstance;

    public event OrderEventHandler Order
    {
        add { _orderEventHandler += value; }
        remove { _orderEventHandler -= value; }
    }
    #endregion

    #region Event Invokers
    internal void InvokeMessageReceived(MessageReceivedArg args) => this.MessageReceived?.Invoke(this, args);
    internal void InvokeConnected(bool args) => this.Connected?.Invoke(this, args);
    internal void InvokeDisConnected(bool args) => this.DisConnected?.Invoke(this, args);
    internal void InvokeErrmessage(ErrMessageArg args) => this.OneErrmessage?.Invoke(this, args);
    #endregion

    /// <summary>
    /// 连接服务器
    /// </summary>
    public  async void ConnectAsync()
    {
        if (mqttClient!=null && mqttClient.IsConnected) return;
        // 创建MQTT客户端
         mqttClient = new MqttFactory().CreateMqttClient();
        // 创建连接选项
        var options = new MqttClientOptionsBuilder()
                    .WithTcpServer(Host, Port) // MQTT代理地址和端口
                    .WithCredentials(UserName, UserPassWord)// 设置MQTT服务器账号和密码
                    .WithClientId(ClientID)// 设置客户端序列号
                    .WithKeepAlivePeriod(TimeSpan.FromSeconds(10))// 设置心跳包时间
                    .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500) // 设置MQTT协议版本
                    .Build();
        //Credentials是设置账号和密码
        //options.Credentials = new MqttClientCredentials("****", Encoding.UTF8.GetBytes("****"));


        //连接事件
        mqttClient.ConnectedAsync += ConnectedHandle;
        //断开连接事件
        mqttClient.DisconnectedAsync += DisconnectedHandle;
        //消息接收事件
        mqttClient.ApplicationMessageReceivedAsync += ApplicationMessageReceivedHandle;
        //连接MQTT服务器
        await mqttClient.ConnectAsync(options);
        //Task.Run(async () =>
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(2000);
        //        // 发布消息
        //        await mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
        //            .WithTopic("xunz") // 主题
        //            .WithPayload("Hello, MQTT ! " + DateTime.Now.ToString("HH :mm :ss"))
        //            .WithRetainFlag()
        //            .Build());
        //    }
        //});
    }
    /// <summary>
    /// 消息订阅
    /// </summary>
    public  async void Subscribe(string topic) {
        try
        {
            await mqttClient.SubscribeAsync(topic);
            if (!listTopic.Contains(topic)) listTopic.Add(topic);
        }
        catch (Exception ex)
        {
            InvokeErrmessage(new ErrMessageArg() { Errmessage = $"Subscribe:{ex.Message}", Exception = ex });
        }
    }
    /// <summary>
    /// 消息发布
    /// </summary>
    /// <param name="topic">主题</param>
    /// <param name="payload">发生信息</param>
    public  async void Publish(string topic, string payload) {
        var appliactionmessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic) // 主题
            .WithPayload(payload)//负载信息
            .WithRetainFlag()//保留标志
            .Build();
        try
        {
            await mqttClient.PublishAsync(appliactionmessage);
        }
        catch (Exception ex)
        {
            InvokeErrmessage(new ErrMessageArg() { Errmessage = $"Publish:{ex.Message}", Exception = ex });
        }
    }

    /// <summary>
    /// 取消订阅
    /// </summary>
    public  async void UnSubscribeAsync(string topic) {

        try
        {
            await mqttClient.UnsubscribeAsync(topic);
            if (listTopic.Contains(topic)) listTopic.Remove(topic);
        }
        catch (Exception ex)
        {
            InvokeErrmessage(new ErrMessageArg() { Errmessage = $"UnsubscribeAsync:{ex.Message}", Exception = ex });
        }
    }

    private  Task ApplicationMessageReceivedHandle(MqttApplicationMessageReceivedEventArgs args)
    {
        InvokeMessageReceived(
                new MessageReceivedArg
                {
                    Topic = args.ApplicationMessage.Topic,
                    Payload = Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment)
                });
        return new Task(() => { });
        return Task.Run(() =>
        {
            //Console.WriteLine("收到消息主题:" + args.ApplicationMessage.Topic);
            //string payload = Encoding.UTF8.GetString(args.ApplicationMessage.Payload);
            //Console.WriteLine("收到消息内容:" + payload);
        });

        //return new Task(action: null);

        //throw new NotImplementedException();
    }

    private  Task DisconnectedHandle(MqttClientDisconnectedEventArgs args)
    {
        InvokeDisConnected(IsConnected =args.ClientWasConnected);
        return new Task(() => { });
    }

    private  Task ConnectedHandle(MqttClientConnectedEventArgs args)
    {
        InvokeConnected( args.ConnectResult.IsSessionPresent);
        return new Task(() => { });
        //throw new NotImplementedException();
    }
}

