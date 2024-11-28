using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    internal class MqttListConfig : IEntityTypeConfiguration<MqttList>
    {
        public void Configure(EntityTypeBuilder<MqttList> builder)
        {
            builder.ToTable("MqttLists");//实体对应数据库表这个名称
            //builder.HasKey(x => x.ID);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();//设置Title的长度为50
            builder.Property(e => e.UserName).HasMaxLength(50).HasDefaultValue("admin").IsRequired();
            builder.Property(e => e.UserPassWord).HasMaxLength(50).HasDefaultValue("admin").IsRequired();//设置Title的长度为50
            builder.Property(e => e.KeepAlive).HasDefaultValue(100).IsRequired();//设置Title的长度为50
            builder.Property(e => e.Port).HasDefaultValue(1883).IsRequired();//设置Title的长度为50
            builder.Property(e => e.Host).HasDefaultValue("127.0.0.1").IsRequired();//设置Title的长度为50

        }   
    }

    internal class MqttSubscriptionConfig : IEntityTypeConfiguration<MqttSubscriptionModel>
    {
        public void Configure(EntityTypeBuilder<MqttSubscriptionModel> builder)
        {
            builder.ToTable("MqttSubscriptionContent");//实体对应数据库表这个名称
            builder.HasOne<MqttList>(c => c.MqttLists).WithMany(a => a.SubscriptionList).IsRequired();
            //builder.Property(e => e.Name).HasMaxLength(50).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.UserName).HasMaxLength(50).HasDefaultValue("admin").IsRequired();
            //builder.Property(e => e.UserPassWord).HasMaxLength(50).HasDefaultValue("admin").IsRequired();//设置Title的长度为50
            //builder.Property(e => e.KeepAlive).HasDefaultValue(100).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.Port).HasDefaultValue(1883).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.Host).HasDefaultValue("127.0.0.1").IsRequired();//设置Title的长度为50

        }
    }

    internal class UserModelConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");//实体对应数据库表这个名称
            //builder.Property(e => e.Name).HasMaxLength(50).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.UserName).HasMaxLength(50).HasDefaultValue("admin").IsRequired();
            //builder.Property(e => e.UserPassWord).HasMaxLength(50).HasDefaultValue("admin").IsRequired();//设置Title的长度为50
            //builder.Property(e => e.KeepAlive).HasDefaultValue(100).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.Port).HasDefaultValue(1883).IsRequired();//设置Title的长度为50
            //builder.Property(e => e.Host).HasDefaultValue("127.0.0.1").IsRequired();//设置Title的长度为50

        }
    }


}
