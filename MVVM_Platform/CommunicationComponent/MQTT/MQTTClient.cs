using CommunicationComponent;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Windows.Input;

public delegate void OrderEventHandler(MQTTClient sender, MessageReceivedArg e);

public  class MQTTClient : ObservableObject
{
    #region 属性
    /// <summary>名称</summary>
    MQTTClientModel model=new ();
    public MQTTClientModel Model { get => model; set { SetProperty(ref model, value); } }
    private IMqttClient mqttClient;
    bool isConnect = false;
    public bool IsConnect { get => isConnect; set { SetProperty(ref isConnect, value); } }

    #endregion

    #region 调用方法
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
        try
        {
            if (mqttClient != null && mqttClient.IsConnected) return;
            // 创建MQTT客户端
            mqttClient = new MqttFactory().CreateMqttClient();
            // 创建连接选项
            var options = new MqttClientOptionsBuilder()
                        .WithTcpServer(model.Host, model.Port) // MQTT代理地址和端口
                        .WithCredentials(model.UserName, model.UserPassWord)// 设置MQTT服务器账号和密码
                        .WithClientId(model.ClientID)// 设置客户端序列号
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
            if (mqttClient.IsConnected && Model.listTopic.Count != 0)
            {
                foreach (var item in Model.listTopic)
                {
                   Subscribe(item.Topic);
                }
            }


            Task.Run(async () =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    // 发布消息
                    await mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
                        .WithTopic("xunz") // 主题
                        .WithPayload("Hello, MQTT ! " + DateTime.Now.ToString("HH :mm :ss"))
                        .WithRetainFlag()
                        .Build());
                }
            });
        }
        catch (Exception ex)
        {
            InvokeErrmessage(new ErrMessageArg() { Errmessage = $"ConnectAsync:{ex.Message}", Exception = ex });
        }

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
            var top = model.listTopic.FirstOrDefault(x => x.Topic == topic);
            if (top != null) model.listTopic.Remove(top);
        }
        catch (Exception ex)
        {
            InvokeErrmessage(new ErrMessageArg() { Errmessage = $"UnsubscribeAsync:{ex.Message}", Exception = ex });
        }
    }

    private  Task ApplicationMessageReceivedHandle(MqttApplicationMessageReceivedEventArgs args)
    {
        var Receive = model.listTopic.FirstOrDefault(x => x.Topic == args.ApplicationMessage.Topic);
        if (Receive!=null)
        {
            Receive.ReceiveMessages.Add(new MqttMessageInfo { Lever=1, Message= Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment) });
        }
        InvokeMessageReceived(
                new MessageReceivedArg
                {
                    Topic = args.ApplicationMessage.Topic,
                    Payload = Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment)
                });
        return Task.CompletedTask;
    }

    private  Task DisconnectedHandle(MqttClientDisconnectedEventArgs args)
    {
        InvokeDisConnected(model.IsConnected =args.ClientWasConnected);
        return Task.CompletedTask;
    }

    private  Task ConnectedHandle(MqttClientConnectedEventArgs args)
    {
        //InvokeConnected(IsConnected =  args.ConnectResult.IsSessionPresent);
        InvokeConnected(IsConnect=model.IsConnected = args.ConnectResult.ResultCode ==0);
        IsConnect = args.ConnectResult.ResultCode == 0;
        return Task.CompletedTask;
        //throw new NotImplementedException();
    }
}

