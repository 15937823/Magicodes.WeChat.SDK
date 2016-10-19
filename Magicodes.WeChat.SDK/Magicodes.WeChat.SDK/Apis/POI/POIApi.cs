// ======================================================================
//  
//          Copyright (C) 2016-2020 ����������Ϣ�Ƽ����޹�˾    
//          All rights reserved
//  
//          filename : POIApi.cs
//          description :
//  
//          created by ����ǿ at  2016/10/19 17:10
//          Blog��http://www.cnblogs.com/codelove/
//          GitHub��https://github.com/xin-lai
//          Home��http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    ///     ��ȯ�ӿ�
    /// </summary>
    public class POIApi : ApiBase
    {
        private const string ApiName = "poi";

        /// <summary>
        ///     ��ȡAccessToken
        /// </summary>
        /// <returns></returns>
        public GetCategoryListApiResult GetCategoryList()
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("getwxcategory", ApiName);
            return Get<GetCategoryListApiResult>(url);
        }
    }
}