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
        public ApiResult UpdateMemberCard(UpdateCardRequest model)
        {
            var url = GetAccessApiUrl("update", ApiName, "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;

        }
        #endregion

        /// <summary>
        /// ���ÿ����ֶνӿ�
        /// �������ڴ���ʱ����wx_activate�ֶκ���Ҫ���øýӿ������û�����ʱ��Ҫ��д��ѡ�����һ���������ò���Ч��
        /// </summary>
        /// <returns></returns>
        public ApiResult ActivateUserForm()
        {
            var url = GetAccessApiUrl("activateuserform/set", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, "");
            return result;
        }
        /// <summary>
        /// �ӿڼ���
        /// �ӿڼ���ͨ����Ҫ�����߿����û���д���ϵ���ҳ��ͨ�������ּ������̣�
        /// 1. �û���������д���Ϻ�����쿨���쿨�󿪷��ߵ��ü���ӿ�Ϊ�û������Ա����
        /// 2. ���û���������ȡ��Ա������������Ա����ת�����������õ�������дҳ�棬��д��ɺ󿪷��ߵ��ü���ӿ�Ϊ�û������Ա����
        /// </summary>
        /// <returns></returns>
        public ApiResult Activate(ActivateRequest model)
        {
            var url = GetAccessApiUrl("activate", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }
        #endregion

        #region �Զ���Code
        /// <summary>
        /// �����Զ���CODE
        /// 1�����ε��ýӿڴ���code����������Ϊ100����
        /// 2��ÿһ�� code ������Ϊ�մ���
        /// 3�����������ϵͳ���Զ��ж��ṩ�����ÿ����ʵ�ʵ���code�����Ƿ�һ�¡�
        /// 4������ʧ��֧���ظ����룬��ʾ�ɹ�Ϊֹ��
        /// </summary>
        /// <param name="cardId">�������</param>
        /// <param name="codeList">�Զ���Code�б�</param>
        /// <returns></returns>
        public DepositCustomCodeResult DepositCustomCode(string cardId, List<string> codeList)
        {
            var url = GetAccessApiUrl("deposit", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = codeList
            };
            var result = Post<DepositCustomCodeResult>(url, data);
            return result;
        }

        /// <summary>
        /// ��ѯ����code��Ŀ�ӿ�,��ѯcode����΢�ź�̨�ɹ�����Ŀ��
        /// </summary>
        /// <returns></returns>
        public GetDepositCountResult GetDepositCount(string cardId)
        {
            var url = GetAccessApiUrl("getdepositcount", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
            };
            var result = Post<GetDepositCountResult>(url, data);
            return result;
        }

        /// <summary>
        /// Ϊ�˱�����ֵ�����ǿ�ҽ��鿪�����ڲ�ѯ��code��Ŀ��ʱ��˲�code�ӿ�У��code����΢�ź�̨�������
        /// </summary>
        /// <param name="cardId">���е���code�Ŀ�ȯID</param>
        /// <param name="codeList">�Ѿ�����΢�ſ�ȯ��̨���Զ���code������Ϊ100����</param>
        /// <returns></returns>
        public CheckCodeResult CheckCode(string cardId, List<string> codeList)
        {
            var url = GetAccessApiUrl("checkcode", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = codeList
            };
            var result = Post<CheckCodeResult>(url, data);
            return result;
        }

        #endregion

        #region �޸Ŀ�ȯ���
        /// <summary>
        /// �޸Ŀ�ȯ���
        /// </summary>
        /// <returns></returns>
        public ApiResult ModifyStock(ModifyStockRequest model)
        {
            var url = GetAccessApiUrl("modifystock", ApiName, "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }
        #endregion

        #region ɾ����ȯ
        /// <summary>
        /// ɾ����ȯ
        /// </summary>
        public ApiResult Delete(string cardId)
        {
            var url = GetAccessApiUrl("delete", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }
        #endregion

        #region ���ÿ�ȯʧЧ�ӿ�
        /// <summary>
        /// ���ÿ�ȯʧЧ�ӿ�
        /// Ϊ�����Ʊ���˿���쳣������ɵ��ÿ�ȯʧЧ�ӿڽ��û��Ŀ�ȯ����ΪʧЧ״̬�� 
        /// 1.���ÿ�ȯʧЧ�Ĳ��������棬���޷�������ΪʧЧ�Ŀ�ȯ������Ч״̬���̼������ص��øýӿڡ�
        /// 2.�̻�����ʧЧ�ӿ�ǰ����˿����ȸ�֪��ȡ��ͬ�⣬������˴����Ĺ˿�Ͷ�ߣ�΢�Ž��ᰴ�ա�΢����Ӫ�������򡷽��д�����
        /// </summary>
        /// <param name="cardId">��Ա�����룬���Զ���Code���Բ���</param>
        /// <param name="code">��Ա��Code</param>
        /// <returns></returns>
        public ApiResult Unavailable(string code, string cardId = null)
        {
            var url = GetAccessApiUrl("unavailable", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = code
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }
        #endregion

        #region Ͷ�ſ�ȯ
        /// <summary>
        /// ������ά��ӿ�
        /// </summary>
        public CreateQRCodeResult CreateQRCode(CreareQRCodeRequest model)
        {
            var url = GetAccessApiUrl("create", "card/qrcode", "https://api.weixin.qq.com");
            var result = Post<CreateQRCodeResult>(url, model);
            return result;
        }
        /// <summary>
        /// ��ȯ����֧�ֿ�����ͨ�����ýӿ�����һ����ȯ��ȡH5ҳ�棬����ȡҳ�����ӣ����п�ȯͶ�Ŷ�����
        /// Ŀǰ��ȯ���ܽ�֧�ַ��Զ���code�Ŀ�ȯ���Զ���code�Ŀ�ȯ���ȵ��õ���code�ӿڽ�code�����������ʹ�á�
        /// ��������ʱ����дͶ��·���ĳ����ֶ�
        /// </summary>
        public CreateLandingPageResult CreateLandingPage(CreateLandingPageRequest model)
        {
            var url = GetAccessApiUrl("create", "card/landingpage", "https://api.weixin.qq.com");
            var result = Post<CreateLandingPageResult>(url, model);
            return result;
        }

        #endregion
    }
}