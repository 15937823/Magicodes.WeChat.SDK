﻿// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;
using Magicodes.WeChat.SDK.Apis.CustomMessage;

namespace Magicodes.WeChat.SDK.Apis.Ticket
{
    /// <summary>
    ///     客服接口
    /// </summary>
    public class TicketApi : ApiBase
    {
        private const string ApiName = "ticket";
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public TicketApiResult Get()
        {
            var url = GetAccessApiUrl("getticket", ApiName, ApiRoot, new Dictionary<string, string>()
            {
                {"type","jsapi" }
            });
            var result = Get<TicketApiResult>(url);
            result.ExporesTime = DateTime.Now.AddSeconds(result.Expires - 30);
            return result;
        }
        /// <summary>
        /// 安全获取AccessToken
        /// </summary>
        /// <returns></returns>
        public TicketApiResult SafeGet()
        {
            var appConfig = AppConfig;
            TicketApiResult ticket;
            if (WeiChatApisContext.Current.AccessTokenConcurrentDictionary.ContainsKey(appConfig.AppId))
            {
                ticket = WeiChatApisContext.Current.TicketConcurrentDictionary[appConfig.AppId];
                if (DateTime.Now < ticket.ExporesTime)
                    return ticket;
                ticket = Get();
                WeiChatApisContext.Current.TicketConcurrentDictionary.AddOrUpdate(appConfig.AppId, ticket,
                    (tKey, existingVal) => ticket);
                return ticket;
            }
            ticket = Get();
            WeiChatApisContext.Current.TicketConcurrentDictionary.AddOrUpdate(appConfig.AppId, ticket, (tKey, existingVal) => ticket);
            return ticket;
        }

    }
}