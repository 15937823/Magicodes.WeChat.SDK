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

using Magicodes.WeChat.SDK.Apis.Card.Request;
using Magicodes.WeChat.SDK.Apis.Card.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     ��ȯ�ӿ�
    /// </summary>
    public class CardApi : ApiBase
    {
        private const string ApiName = "card";

        #region �Ż�ȯ

        #region ����Ż�ȯ

        /// <summary>
        ///     ����Ż�ȯ
        /// </summary>
        /// <param name="cardInfo">��ȯ�ṹ����</param>
        /// <returns></returns>
        public ApiResult Add(CardInfo cardInfo)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("create", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card = cardInfo
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }

        /// <summary>
        ///     ����Ż�ȯ
        /// </summary>
        /// <param name="cardInfoJson">��ȯJSON�ṹ�ַ���</param>
        /// <returns></returns>
        public ApiResult AddByJson(string cardInfoJson)
        {
            return Add(GetCardInfoByJson(cardInfoJson));
        }

        #endregion

        #region ���ݿ�ȯJSON�ṹ�ַ�����ȡ�Ż�ȯ��Ϣ
        /// <summary>
        ///     ���ݿ�ȯJSON�ṹ�ַ�����ȡ�Ż�ȯ��Ϣ
        /// </summary>
        /// <returns></returns>
        public CardInfo GetCardInfoByJson(string cardInfoJson)
        {
            return JsonConvert.DeserializeObject<CardInfo>(cardInfoJson, new CardInfoCustomConverter(), new DateInfoCustomConverter());
        }
        #endregion

        #endregion


        #region �ϴ�ͼƬ
        /// <summary>
        ///     �ϴ���ȯͼƬ
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="fileStream">�ļ���</param>
        /// <returns></returns>
        public UploadImageApiResult UploadImage(string fileName, Stream fileStream)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("uploadimg", "media");
            return Post<UploadImageApiResult>(url, fileName, fileStream);
        }
        #endregion

        #region ��Ա��

        #region ���ݿ�ȯJSON�ṹ�ַ�����ȡ��Ա����Ϣ
        /// <summary>
        ///     ���ݿ�ȯJSON�ṹ�ַ�����ȡ��Ա����Ϣ
        /// </summary>
        /// <returns></returns>
        public MemberCard GetMemberCardByJson(string cardInfoJson)
        {
            return JsonConvert.DeserializeObject<MemberCard>(cardInfoJson, new MemberCardCustomConverter(), new DateInfoCustomConverter());
        }
        #endregion 

        #region ��ӻ�Ա��
        /// <summary>
        ///     ��ӻ�Ա��
        /// </summary>
        /// <param name="cardInfo">��ȯ�ṹ����</param>
        /// <returns></returns>
        public ApiResult AddMemberCard(MemberCardInfo cardInfo)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("create", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card = cardInfo
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }

        /// <summary>
        ///     ��ӻ�Ա��
        /// </summary>
        /// <param name="cardInfoJson">��ȯJSON�ṹ�ַ���</param>
        /// <returns></returns>
        public ApiResult AddMemberCardByJson(string cardInfoJson)
        {
            return Add(GetCardInfoByJson(cardInfoJson));
        }
        #endregion

        #region �����Ա��
        /// <summary>
        /// �ӿڼ����Ա��
        /// ���ʽ˵��
        /// �ӿڼ���ͨ����Ҫ�����߿����û���д���ϵ���ҳ��ͨ�������ּ������̣�
        /// 1. �û���������д���Ϻ�����쿨���쿨�󿪷��ߵ��ü���ӿ�Ϊ�û������Ա����
        /// 2. ���û���������ȡ��Ա������������Ա����ת�����������õ�������дҳ�棬��д��ɺ󿪷��ߵ��ü���ӿ�Ϊ�û������Ա����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResult AcitveMember(ActivateMemberCardRequest model)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("activate", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }

        /// <summary>
        /// ��ͨһ�������Ա��
        /// ����һ���ڴ����ӿ�����wx_activate�ֶ�
        /// ����������ÿ����ֶνӿ�
        /// �����������ջ�Ա��Ϣ�¼�֪ͨ
        /// �����ģ�ͬ����Ա����
        /// �����壺��ȡ��Ա��Ϣ�ӿ�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResult ActivateMemberUserform(ActivateMemberCardRequest model)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("activateuserform", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }

        /// <summary>
        /// ��ת��һ������֧���û����ύ��Ա�������Ϻ���ת���̻��Զ������ҳ��
        /// ��ͬ����ͨһ�������ת��һ������ļ����Ա���������̻���ɣ��̻���������ת������ҳ�����������������������жϵ��߼���ͬʱҲ��֤�˿�����ʵʱ�ԣ��ʺ�ʹ���Զ��忨�ŵ��̻�ʹ�á�
        /// ����һ���ڴ���/���½ӿ�������ת��һ����������ֶ�
        /// ����������ÿ����ֶνӿ�
        /// ����������ȡ�û��ύ����
        /// �����ģ����ýӿڼ����Ա��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActivateMemberTempInfoResult Activatetempinfo(ActivateMemberTempInfoRequest model)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("activatetempinfo", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ActivateMemberTempInfoResult>(url, model);
            return result;
        }

        #endregion

        #region ��ȡ��Ա��Ϣ�����ֲ�ѯ���ӿ�
        /// <summary>
        /// ��ȡ��Ա��Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GetUserInfoResult GetUserInfo(GetUserInfoRequest model)
        {
            var url = GetAccessApiUrl("userinfo/get", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<GetUserInfoResult>(url, model);
            return result;
        }
        #endregion

        #region ���»�Ա��Ϣ
        /// <summary>
        ///  ����Ա�ֿ����Ѻ�֧�ֿ����ߵ��øýӿڸ��»�Ա��Ϣ����Ա�����׺��ÿ����Ϣ�����ͨ���ýӿ�֪ͨ΢�ţ����ں�����Ϣ֪ͨ��������չ���ܡ�
        ///  ֵ��ע����ǣ����������������ʵʱͬ�����֡������΢�Ŷˣ�����ǿ�ҽ��鿪���߿�����ÿ��Ĺ̶�ʱ��������֣�һ�첻�������Ρ�������Ļ���ֵ��֮ǰ�ޱ仯ʱ�������bonus=ԭ����bonus���������л��ֱ䶯֪ͨ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UpdateUserResult UpdateUser(UpdateUserRequest model)
        {
            //��ȡapi����url
            var url = GetAccessApiUrl("updateuser", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<UpdateUserResult>(url, model);
            return result;
        }
        #endregion

        #region ���»�Ա����Ϣ
        public void UpdateCard()
        {

        }
        #endregion



        #endregion
    }
}