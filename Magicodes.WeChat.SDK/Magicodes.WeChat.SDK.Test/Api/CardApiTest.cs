﻿// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomerServiceApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.Card;
using Magicodes.WeChat.SDK.Apis.CustomerService;
using Magicodes.WeChat.SDK.Apis.POI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class CardApiTest : ApiTestBase
    {
        private readonly CardApi _weChatApi = WeChatApisContext.Current.CardApi;

        [TestMethod]
        public void CardApiTest_Add()
        {
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());

                CardInfo cardInfo = new Groupon()
                {
                    Groupon_ = new Groupon.GrouponInfo()
                    {
                        BaseInfo = new BaseInfo()
                        {
                            LogoUrl = result.Url,
                            BrandName = "Test",
                            CodeType = CodeTypes.CODE_TYPE_TEXT,
                            Title = "Test套餐",
                            Color = "Color010",
                            Notice = "使用时向服务员出示此券",
                            ServicePhone = "020-88888888",
                            Description = "不可与其他优惠同享\n如需团购券发票，请在消费时向商户提出\n店内均可使用，仅限堂食",
                            DateInfo = new FixTimeRangeDateInfo()
                            {
                                BeginTime = DateTime.Now,
                                EndTime = DateTime.Now.AddMonths(1),
                            },
                            Sku = new Sku()
                            {
                                Quantity = 500000
                            },
                            GetLimit = 3,
                            UseCustomCode = false,
                            BindOpenId = false,
                            CanShare = true,
                            CanGiveFriend = true,
                            LocationIdList = new int[] { 123, 12321, 345345 },
                            CenterTitle = "顶部居中按钮",
                            CenterSubTitle = "按钮下方的wording",
                            CenterUrl = "http://xin-lai.com",
                            CustomUrlName = "立即使用",
                            CustomUrl = "http://xin-lai.com",
                            CustomUrlSubTitle = "6个汉字tips",
                            PromotionUrlName = "更多优惠",
                            PromotionUrl = "http://xin-lai.com",
                            Source = "美团"
                        },
                        //AdvancedInfo = new AdvancedInfo()
                        //{
                        //    UseCondition = new UseCondition()
                        //    {
                        //        AcceptCategory = "Test类",
                        //        RejectCategory = "Test",
                        //        CanUseWithOtherDiscount = true
                        //    },
                        //    Abstract = new Abstract()
                        //    {
                        //        AbstractInfo = "多种新季菜品，期待您的光临",
                        //        IconUrlList = new string[] { result.Url }
                        //    },
                        //    TextImageList = new TextImageList[]
                        //    {
                        //        new TextImageList() { ImageUrl=result.Url,Text="此菜品精选食材，以独特的烹饪方法，最大程度地刺激食 客的味蕾" },
                        //        new TextImageList() { ImageUrl=result.Url,Text="此菜品迎合大众口味，老少皆宜，营养均衡" },
                        //    },
                        //    TimeLimit = new TimeLimit[]{
                        //        new TimeLimit()
                        //        {
                        //            Type = TimeLimitTypes.MONDAY,
                        //            BeginHour = 0,
                        //            EndHour = 10,
                        //            BeginMinute = 10,
                        //            EndMinute = 59
                        //        },
                        //        new TimeLimit()
                        //        {
                        //            Type = TimeLimitTypes.HOLIDAY
                        //        }
                        //    },
                        //    BusinessService = new string[] {
                        //        "BIZ_SERVICE_FREE_WIFI",
                        //        "BIZ_SERVICE_WITH_PET",
                        //        "BIZ_SERVICE_FREE_PARK",
                        //        "BIZ_SERVICE_DELIVER"
                        //    }
                        //},
                        DealDetail = "以下锅底2选1（有菌王锅、麻辣锅、大骨锅、番茄锅、清补 凉锅、酸菜鱼锅可选）：\n大锅1份 12元\n小锅2份 16元"
                    }
                };
                var cardResult = _weChatApi.Add(cardInfo);
                if (!cardResult.IsSuccess())
                    Assert.Fail("创建卡券失败，返回结果如下：" + cardResult.DetailResult + "；Msg:" + cardResult.GetFriendlyMessage());
            }

        }

        [TestMethod]
        public void CardApiTest_Add_ByJSON()
        {
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());
                var jsonStr = @"
{
  ""card_type"": ""GROUPON"",
  ""groupon"":{
      ""base_info"": {
        ""logo_url"": ""{logo_url}"",
        ""brand_name"": ""Test"",
        ""code_type"": ""CODE_TYPE_QRCODE"",
        ""title"": ""Test"",
        ""sub_title"": ""Test"",
        ""color"": ""Color020"",
        ""notice"": ""Test"",
        ""service_phone"": ""Test"",
        ""description"": ""阿达啥的"",
        ""date_info"": {
          ""type"": ""DATE_TYPE_FIX_TIME_RANGE"",
          ""begin_time"": ""2016-11-09"",
          ""end_time"": ""2017-11-09"",
          ""fixed_term"": 15,
          ""fixed_begin_term"": 0
        },
        ""sku"": {
          ""quantity"": 500000
        },
        ""get_limit"": 0,
        ""use_custom_code"": false,
        ""bind_openid"": false,
        ""can_share"": true,
        ""can_give_friend"": true,
        ""location_id_list"": [],
        ""center_title"": ""撒啊"",
        ""center_sub_title"": ""啊啊啊"",
        ""center_url"": """",
        ""custom_url_name"": """",
        ""custom_url"": """",
        ""custom_url_sub_title"": """",
        ""promotion_url_name"": """",
        ""promotion_url"": """",
        ""source"": """"
      },
      ""advanced_info"": {
        ""use_condition"": {
          ""accept_category"": """",
          ""reject_category"": """",
          ""least_cost"": 0,
          ""object_use_for"": """",
          ""can_use_with_other_discount"": true
        },
        ""abstract"": {
          ""abstract"": """",
          ""icon_url_list"": []
        },
        ""text_image_list"": [],
        ""time_limit"": [
          {
            ""type"": ""MONDAY"",
            ""begin_hour"": 0,
            ""end_hour"": 10,
            ""begin_minute"": 10,
            ""end_minute"": 59
          },
          {
            ""type"": ""HOLIDAY""
          }
        ],
        ""business_service"": [
          ""BIZ_SERVICE_FREE_WIFI"",
          ""BIZ_SERVICE_WITH_PET"",
          ""BIZ_SERVICE_FREE_PARK"",
          ""BIZ_SERVICE_DELIVER""
        ]
      },
      ""default_detail"": """",
      ""gift"": """",
      ""discount"": 30,
      ""reduce_cost"": 10,
      ""least_cost"": 0,
      ""deal_detail"": ""Test""
    }
}
";
                jsonStr = jsonStr.Replace("{logo_url}", result.Url);
                var obj = _weChatApi.GetCardInfoByJson(jsonStr);
                if (obj == null)
                {
                    Assert.Fail("反序列化对象失败！");
                }
                if (obj is Groupon)
                {
                    var groupon = obj as Groupon;
                    if (groupon.Groupon_.BaseInfo.DateInfo is FixTimeRangeDateInfo)
                    {
                        var cardResult = _weChatApi.Add(obj);
                        if (!cardResult.IsSuccess())
                            Assert.Fail("创建卡券失败，返回结果如下：" + cardResult.DetailResult + "；Msg:" + cardResult.GetFriendlyMessage());
                    }
                    else
                    {
                        Assert.Fail("反序列化对象失败！");
                    }
                }
                else
                {
                    Assert.Fail("反序列化对象失败！");
                }

            }

        }

        [TestMethod()]
        public void AddMemberCard()
        {
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());
                CardInfo cardInfo = new MemberCardInfo()
                {
                    CardType = CardTypes.MEMBER_CARD,
                    MemberCard = new MemberCard()
                    {
                        BackgroundPicUrl = result.Url,
                        Baseinfo = new MemberBaseInfo()
                        {
                            Logo_url = result.Url,
                            Brand_name = "Test",
                            Code_type = CodeTypes.CODE_TYPE_TEXT,
                            Title = "Test套餐",
                            Color = "Color010",
                            Notice = "使用时向服务员出示此券",
                            Service_phone = "020-88888888",
                            Description = "不可与其他优惠同享\n如需团购券发票，请在消费时向商户提出\n店内均可使用，仅限堂食",
                            Date_info = new FixTimeRangeDateInfo()
                            {
                                BeginTime = DateTime.Now,
                                EndTime = DateTime.Now.AddMonths(1),
                            },
                            Sku = new Sku()
                            {
                                Quantity = 500000
                            },
                            GetLimit = 1,
                            Use_custom_code = false,
                            Bind_openid = false,
                            Can_share = true,
                            Can_give_friend = true,
                            Location_id_list = new int[] { 123, 12321, 345345 },
                            Center_title = "顶部居中按钮",
                            Center_sub_title = "按钮下方的wording",
                            Center_url = "http://xin-lai.com",
                            Custom_url_name = "立即使用",
                            Custom_url = "http://xin-lai.com",
                            Custom_url_sub_title = "6个汉字tips",
                            Promotion_url_name = "更多优惠",
                            Promotion_url = "http://xin-lai.com",
                            Promotion_url_sub_title = "美团",
                            Need_push_on_view = false
                        },
                        SupplyBonus = false,
                        Prerogative = "测试会员卡",
                        AutoActivate = true,
                        ActivateUrl = "http://www.baidu.com",
                        CustomCell1 = new CustomCell()
                        {
                            Name = "使用入口",
                            Tips = "立即使用",
                            Url = "http://www.baidu.com"
                        },
                        Discount = 10
                    }

                };
                var cardResult = _weChatApi.Add(cardInfo);
                if (!cardResult.IsSuccess())
                {
                    Assert.Fail("创建会员卡失败，返回结果如下：" + cardResult.DetailResult + "；Msg:" + cardResult.GetFriendlyMessage());
                }
                else
                {
                    Assert.Fail("创建会员卡成功，返回结果如下:" + cardResult.DetailResult + ";Msg:" + cardResult.GetFriendlyMessage());
                }
                    
            }
              
        }
    }
}