// ======================================================================
//  
//          Copyright (C) 2016-2020 ����������Ϣ�Ƽ����޹�˾    
//          All rights reserved
//  
//          filename : CardApi.cs
//          description :
//  
//          created by ����ǿ at  2016/10/13 17:10
//          Blog��http://www.cnblogs.com/codelove/
//          GitHub��https://github.com/xin-lai
//          Home��http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     ��ȯ�ӿ�
    /// </summary>
    public class CardApi : ApiBase
    {
        private const string ApiName = "card";

        /// <summary>
        ///     ��ȡAccessToken
        /// </summary>
        /// <returns></returns>
        public ApiResult Add(CardInfo cardInfo)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("create", ApiName);
            var result = Post<ApiResult>(url, cardInfo);
            return result;
        }


    }
}