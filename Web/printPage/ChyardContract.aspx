<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChyardContract.aspx.cs"
    Inherits="Eyousoft_yhq.Web.printPage.ChyardContract" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/print.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/jquery.easydrag.handler.beta2.js" type="text/javascript"></script>

    <style type="text/css">
        .inputtext
        {
            outline: none;
            border: solid 1px #93B7CE;
            font-size: 12px;
            padding: 1px 2px;
            height: 80px;
            transition: all 0.5s;
            -o-transition: all 0.5s;
            -moz-transition: all 0.5s;
            -ms-transition: all 0.5s;
            -webkit-transition: all 0.5s;
            border-radius: 3px;
        }
    </style>
</head>
<body>
    <form id="form1">
    <div>
        <asp:PlaceHolder ID="plac_ADDRESS" runat="server" Visible="false">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
                <tbody>
                    <tr class="">
                        <td height="40" bgcolor="" colspan="14">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="80" align="center" class="tjbtn02">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="Basic_t">
                <tr>
                    <td align="center">
                        收货人姓名：
                    </td>
                    <td align="left">
                        <asp:Label ID="contactname" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        收货地址：
                    </td>
                    <td align="left">
                        <asp:Label ID="ADDRESS" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        邮政编码：
                    </td>
                    <td align="left">
                        <asp:Label ID="zpcode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        手机号码：
                    </td>
                    <td align="left">
                        <asp:Label ID="mobileNum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        固定电话：
                    </td>
                    <td align="left">
                        <asp:Label ID="telNum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
                <tbody>
                    <tr class="">
                        <td height="40" bgcolor="" colspan="14">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="80" align="center" class="tjbtn02">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:PlaceHolder>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
          <table width="696" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="40" colspan="2" align="left" class="font16">GF-2014-2401</p></td>
  </tr>
  <tr>
    <td height="40" colspan="2" align="center" class="font24">团队境内旅游合同</td>
  </tr>
  <tr>
    <td height="40" colspan="2" align="center" class="font20">（示范文本）</td>
  </tr>
  <tr>
    <td width="471" height="30" align="right" class="font18">国　　家　旅　游　局</td>
    <td rowspan="2" align="left" class="font18">　制定</td>
  </tr>
  <tr>
    <td height="30" align="right" class="font18">国家工商行政管理总局</td>
  </tr>
  <tr>
    <td height="30" colspan="2" align="right" class="font18">二〇一四年四月</td>
  </tr>
</table>
<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="Basic_t">
  <tr>
    <th height="40" align="center">使用说明</th>
  </tr>
  <tr>
    <td align="left">1、本合同为示范文本，供中华人民共和国境内（不含港、澳、台地区）旅行社与旅游者之间签订团队境内包价旅游合同时使用（不含赴港、澳、台地区旅游及边境游）。</td>
  </tr>
  <tr>
    <td align="left">2、双方当事人应当结合具体情况选择本合同协议条款中所提供的选择项，空格处应当以文字形式填写完整。</td>
  </tr>
  <tr>
    <td align="left">3、双方当事人可以书面形式对本示范文本内容予以变更或者补充，但变更或者补充的内容，不得减轻或者免除应当由旅行社承担的责任。</td>
  </tr>
  <tr>
    <td align="left">4、本示范文本由国家旅游局和国家工商行政管理总局共同制定、解释，在全国范围内推行使用。</td>
  </tr>
</table>


<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="Basic_t">
  <tr>
    <th height="40" align="center">团队国内旅游合同</th>
  </tr>
  <tr>
    <td align="right">合同编号：<input type="text" name="textfield" id="textfield" class="Basic_input input300"></td>
  </tr>
  <tr>
    <td>旅游者：<input name="" type="text" class="Basic_input input120">等<input name="" type="text" class="Basic_input input80">      人（名单可附页，需旅行社和旅游者代表签字盖章确认）；</td>
  </tr>
  <tr>
    <td>旅行社：<input type="text" name="textfield" id="textfield" class="Basic_input input425">；</td>
  </tr>
  <tr>
    <td>旅行社业务经营许可证编号：<input type="text" name="textfield" id="textfield" class="Basic_input input300">；</td>
  </tr>
</table>

<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第一章&nbsp;&nbsp;术语和定义</p></th>
  </tr>
  <tr>
    <td align="left">第一条    　本合同术语和定义</td>
  </tr>
  <tr>
    <td class="indent">1、团队境内旅游服务，指旅行社依据《中华人民共和国旅游法》、《旅行社条例》等法律、法规，组织旅游者在中华人民共和国境内（不含香港、澳门、台湾地区）旅游，代订公共交通客票，提供餐饮、住宿、游览等两项以上服务活动。</td>
  </tr>
  <tr>
    <td class="indent">2、旅游费用，指旅游者支付给旅行社，用于购买本合同约定的旅游服务的费用。</td>
  </tr>
  <tr>
    <td class="indent">旅游费用包括：</td>
  </tr>
  <tr>
    <td class="indent2">（1）交通费；</td>
  </tr>
  <tr>
    <td class="indent2">（2）住宿费；</td>
  </tr>
  <tr>
    <td class="indent2">（3）餐费（不含酒水费）</td>
  </tr>
  <tr>
    <td class="indent2">（4）
    旅行社统一安排的景区景点门票费；</p></td>
  </tr>
  <tr>
    <td class="indent2">（5）
    行程中安排的其他项目费用；</p></td>
  </tr>
  <tr>
    <td class="indent2">（6）
    导游服务费；</p></td>
  </tr>
  <tr>
    <td class="indent2">（7） 旅行社（含地接社）的其他服务费用。</p></td>
  </tr>
  <tr>
    <td class="indent">旅游费用不包括：</td>
  </tr>
  <tr>
    <td class="indent2">（1）
      旅游者投保的人身意外伤害保险费用</p>
    ；</td>
  </tr>
  <tr>
    <td class="indent2">（2）
    合同未约定由旅行社支付的费用，包括但不限于行程以外非合同约定活动项目所需的费用、自行安排活动期间发生的费用；</p></td>
  </tr>
  <tr>
    <td class="indent2">（3）
    行程中发生的旅游者个人费用，包括但不限于交通工具上的非免费餐饮费、行李超重费，住宿期间的洗衣、电话、饮料及酒类费，个人娱乐费用，个人伤病医疗费，寻找个人遗失物品的费用及报酬，个人原因造成的赔偿费用。</p></td>
  </tr>
  <tr></tr>
  <tr>
    <td class="indent">3、履行辅助人，指与旅行社存在合同关系，协助其履行本合同义务，实际提供相关服务的法人、自然人或者其他组织。</td>
  </tr>
  <tr>
    <td class="indent">4、自由活动，特指《旅游行程单》中安排的自由活动。</td>
  </tr>
  <tr>
    <td class="indent">5、自行安排活动期间，指《旅游行程单》中安排的自由活动期间、旅游者不参加旅游行程活动期间、每日行程开始前、结束后旅游者离开住宿设施的个人活动期间、旅游者经导游同意暂时离团的个人活动期间。</td>
  </tr>
  <tr>
    <td class="indent">6、不合理的低价，指旅行社提供服务的价格低于接待和服务费用或者低于行业公认的合理价格，且无正当理由和充分证据证明该价格的合理性。其中，接待和服务费用主要包括旅行社提供或者采购餐饮、住宿、交通、游览、导游等服务所支出的费用。</td>
  </tr>
  <tr>
    <td class="indent">7、具体购物场所，指购物场所有独立的商号以及相对清晰、封闭、独立的经营边界和明确的经营主体，包括免税店，大型购物商场，前店后厂的购物场所，景区内购物场所，景区周边或者通往景区途中的购物场所，服务旅游团队的专门商店，商品批发市场和与餐饮、娱乐、停车休息等相关联的购物场所等。</td>
  </tr>
  <tr>
    <td class="indent">8、旅游者投保的人身意外伤害保险，指旅游者自己购买或者通过旅行社、航空机票代理点、景区等保险代理机构购买的以旅行期间自身的生命、身体或者有关利益为保险标的的短期保险，包括但不限于航空意外险、旅游意外险、紧急救援保险、特殊项目意外险。</td>
  </tr>
  <tr>
    <td class="indent">9、离团，指团队旅游者经导游同意不随团队完成约定行程的行为。</td>
  </tr>
  <tr>
    <td class="indent">10、脱团，指团队旅游者未经导游同意脱离旅游团队，不随团队完成约定行程的行为。</td>
  </tr>
  <tr>
    <td class="indent">11、转团，指由于未达到约定成团人数不能出团，旅行社征得旅游者书面同意，在行程开始前将旅游者转至其他旅行社所组的境内旅游团队履行合同的行为。</td>
  </tr>
  <tr>
    <td class="indent">12、拼团，指旅行社在保证所承诺的服务内容和标准不变的前提下，在签订合同时经旅游者同意，与其他旅行社招徕的旅游者拼成一个团，统一安排旅游服务的行为。</td>
  </tr>
  <tr>
    <td class="indent">13、不可抗力，指不能预见、不能避免并不能克服的客观情况，包括但不限于因自然原因和社会原因引起的，如自然灾害、战争、恐怖活动、动乱、骚乱、罢工、突发公共卫生事件、政府行为。</td>
  </tr>
  <tr>
    <td class="indent">14、已尽合理注意义务仍不能避免的事件，指因当事人故意或者过失以外的客观因素引发的事件，包括但不限于重大礼宾活动导致的交通堵塞，飞机、火车、班轮、城际客运班车等公共客运交通工具延误或者取消，景点临时不开放。</td>
  </tr>
  <tr>
    <td class="indent">15、必要的费用，指旅行社履行合同已经发生的费用以及向地接社或者履行辅助人支付且不可退还的费用，包括乘坐飞机（车、船）等交通工具的费用（含预订金）、饭店住宿费用（含预订金）、旅游观光汽车的人均车租等。</td>
  </tr>
  <tr>
    <td class="indent">16、公共交通经营者，指航空、铁路、航运客轮、城市公交、地铁等公共交通工具经营者。</td>
  </tr>
  <tr></tr>
</table>

<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第二章&nbsp;合同的签订</th>
  </tr>
  <tr>
    <td align="left">第二条    　旅游行程单</td>
  </tr>
  <tr>
    <td class="indent">旅行社应当提供带团号的《旅游行程单》（以下简称《行程单》），经双方签字或者盖章确认后作为本合同的组成部分。《行程单》应当对如下内容作出明确的说明：</td>
  </tr>
  <tr>
    <td class="indent2">（1）旅游行程的出发地、途经地、目的地、结束地，线路行程时间和具体安排（按自然日计算，含乘飞机、车、船等在途时间，不足24小时以一日计）；</td>
  </tr>
  <tr>
    <td class="indent2">（2）地接社的名称、地址、联系人和联系电话；</td>
  </tr>
  <tr>
    <td class="indent2">（3）交通服务安排及其标准（明确交通工具及档次等级、出发时间以及是否需中转等信息）；</td>
  </tr>
  <tr>
    <td class="indent2">（4）住宿服务安排及其标准（明确住宿饭店的名称、地点、星级，非星级饭店应当注明是否有空调、热水、独立卫生间等相关服务设施）；</td>
  </tr>
  <tr>
    <td class="indent2">（5）用餐（早餐和正餐）服务安排及其标准（明确用餐次数、地点、标准）；</td>
  </tr>
  <tr>
    <td class="indent2">（6）旅行社统一安排的游览项目的具体内容及时间（明确旅游线路内容包括景区点及游览项目名称等，景区点停留的最少时间）；</td>
  </tr>
  <tr>
    <td class="indent2">（7）自由活动的时间；</td>
  </tr>
  <tr>
    <td class="indent2">（8）行程安排的娱乐活动（明确娱乐活动的时间、地点和项目内容）；</td>
  </tr>
  <tr>
    <td class="indent">《行程单》用语须准确清晰，在表明服务标准用语中不应当出现&#8220;准&#215;星级&#8221;、&#8220;豪华&#8221;、&#8220;仅供参考&#8221;、&#8220;以&#215;&#215;为准&#8221;、&#8220;与&#215;&#215;同级&#8221;等不确定用语。</td>
  </tr>
  <tr>
    <td>第三条    　订立合同</td>
  </tr>
  <tr>
    <td class="indent">旅游者应当认真阅读本合同条款、《行程单》，在旅游者理解本合同条款及有关附件后，旅行社和旅游者应当签订书面合同。</td>
  </tr>
  <tr>
    <td class="indent">由旅游者的代理人订立合同的，代理人需要出具被代理的旅游者的授权委托书。</td>
  </tr>
  <tr>
    <td>第四条    　旅游广告及宣传品</td>
  </tr>
  <tr>
    <td class="indent">旅行社的旅游广告及宣传品应当遵循诚实信用的原则，其内容符合《中华人民共和国合同法》要约规定的，视为本合同的组成部分，对旅行社和旅游者双方具有约束力。</td>
  </tr>
</table>

<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第三章&nbsp;&nbsp;&nbsp;&nbsp;合同双方的权利义务</th>
  </tr>
  <tr>
    <td align="left">第五条    　&nbsp;旅行社的权利</td>
  </tr>
  <tr>
    <td class="indent">1、根据旅游者的身体健康状况及相关条件决定是否接纳旅游者报名参团；</td>
  </tr>
  <tr>
    <td class="indent">2、核实旅游者提供的相关信息资料；</td>
  </tr>
  <tr>
    <td class="indent">3、按照合同约定向旅游者收取全额旅游费用；</td>
  </tr>
  <tr>
    <td class="indent">4、旅游团队遇紧急情况时，可以采取紧急避险措施并要求旅游者配合；</td>
  </tr>
  <tr>
    <td class="indent">5、拒绝旅游者提出的超出合同约定的不合理要求；</td>
  </tr>
  <tr>
    <td class="indent">6、&nbsp;要求旅游者对在旅游活动中或者在解决纠纷时损害旅行社合法权益的行为承担赔偿责任；</td>
  </tr>
  <tr>
    <td class="indent">7、要求旅游者健康、文明旅游，劝阻旅游者违法和违反社会公德的行为。</td>
  </tr>
  <tr>
    <td>第六条    　旅行社的义务</td>
  </tr>
  <tr>
    <td class="indent">1、按照合同和《行程单》约定的内容和标准为旅游者提供服务，不擅自变更旅游行程安排；</td>
  </tr>
  <tr>
    <td class="indent">2、向合格的供应商订购产品和服务；</td>
  </tr>
  <tr>
    <td class="indent">3、不以不合理的低价组织旅游活动，诱骗旅游者，并通过安排购物或者另行付费旅游项目获取回扣等不正当利益；</td>
  </tr>
  <tr>
    <td class="indent">组织、接待旅游者，不指定具体购物场所，不安排另行付费旅游项目，但是，经双方协商一致或者旅游者要求，且不影响其他旅游者行程安排的除外；</td>
  </tr>
  <tr>
    <td class="indent">4、在出团前如实告知具体行程安排和有关具体事项，具体事项包括但不限于所到旅游目的地的重要规定、风俗习惯；旅游活动中的安全注意事项和安全避险措施、旅游者不适合参加旅游活动的情形；旅行社依法可以减免责任的信息；应急联络方式以及法律、法规规定的其他应当告知的事项；</td>
  </tr>
  <tr>
    <td class="indent">5、按照合同约定，为旅游团队安排符合《中华人民共和国旅游法》、《导游人员管理条例》规定的持证导游人员；</td>
  </tr>
  <tr>
    <td class="indent">6、妥善保管旅游者交其代管的证件、行李等物品；</td>
  </tr>
  <tr>
    <td class="indent">7、为旅游者发放用固定格式书写、由旅游者填写的安全信息卡（包括旅游者的姓名、血型、应急联络方式等）；</td>
  </tr>
  <tr>
    <td class="indent">8、旅游者人身、财产权益受到损害时，应当采取合理必要的保护和救助措施，避免旅游者人身、财产权益损失扩大；</td>
  </tr>
  <tr>
    <td class="indent">9、积极协调处理旅游行程中的纠纷，采取适当措施防止损失扩大；</td>
  </tr>
  <tr>
    <td class="indent">10、提示旅游者投保人身意外伤害保险；</td>
  </tr>
  <tr>
    <td class="indent">11、向旅游者提供发票；</td>
  </tr>
  <tr>
    <td class="indent">12、依法对旅游者个人信息保密；</td>
  </tr>
  <tr>
    <td class="indent">13、旅游行程中解除合同的，旅行社应当协助旅游者返回出发地或者旅游者指定的合理地点。</td>
  </tr>
  <tr>
    <td>第七条    　旅游者的权利</td>
  </tr>
  <tr>
    <td class="indent">1、要求旅行社按照合同及《行程单》约定履行相关义务；</td>
  </tr>
  <tr>
    <td class="indent">2、拒绝未经事先协商一致的转团、拼团行为；</td>
  </tr>
  <tr>
    <td class="indent">3、有权自主选择旅游产品和服务，有权拒绝旅行社未与旅游者协商一致或者未经旅游者要求而指定购物场所、安排旅游者参加另行付费旅游项目的行为，有权拒绝旅行社的导游强迫或者变相强迫旅游者购物、参加另行付费旅游项目的行为；</td>
  </tr>
  <tr>
    <td class="indent">4、在支付旅游费用时要求旅行社出具发票；&nbsp;</td>
  </tr>
  <tr>
    <td class="indent">5、人格尊严、民族风俗习惯和宗教信仰得到尊重；</td>
  </tr>
  <tr>
    <td class="indent">6、在人身、财产安全遇有危险时，有权请求救助和保护；人身、财产受到损害的，有权依法获得赔偿；</td>
  </tr>
  <tr>
    <td class="indent">7、在合法权益受到损害时向有关部门投诉或者要求旅行社协助索赔；</td>
  </tr>
  <tr>
    <td class="indent">8、《中华人民共和国旅游法》、《中华人民共和国消费者权益保护法》和有关法律、法规赋予旅游者的其他各项权利。</td>
  </tr>
  <tr></tr>
  <tr>
    <td>第八条    　旅游者的义务    </td>
  </tr>
  <tr>
    <td class="indent">1、如实填写《旅游报名表》、游客安全信息卡等各项内容，告知与旅游活动相关的个人健康信息，并对其真实性负责，保证所提供的联系方式准确无误且能及时联系；</td>
  </tr>
  <tr>
    <td class="indent">2、按照合同约定支付旅游费用；</td>
  </tr>
  <tr>
    <td class="indent">3、遵守法律、法规和有关规定，不在旅游行程中从事违法活动，不参与色情、赌博和涉毒活动；</td>
  </tr>
  <tr>
    <td class="indent">4、遵守公共秩序和社会公德，尊重旅游目的地的风俗习惯、文化传统和宗教信仰，爱护旅游资源，保护生态环境，遵守《中国公民国内旅游文明行为公约》等文明行为规范；</td>
  </tr>
  <tr>
    <td class="indent">5、对国家应对重大突发事件暂时限制旅游活动的措施以及有关部门、机构或者旅游经营者采取的安全防范和应急处置措施予以配合；</td>
  </tr>
  <tr>
    <td class="indent">6、妥善保管自己的行李物品，随身携带现金、有价证券、贵重物品，不在行李中夹带；</td>
  </tr>
  <tr>
    <td class="indent">7、在旅游活动中或者在解决纠纷时，应采取措施防止损失扩大，不损害当地居民的合法权益；不干扰他人的旅游活动；不损害旅游经营者和旅游从业人员的合法权益，不采取拒绝上、下机（车、船）、拖延行程或者脱团等不当行为；&nbsp;</td>
  </tr>
  <tr>
    <td class="indent">8、自行安排活动期间，应当在自己能够控制风险的范围内选择活动项目，遵守旅游活动中的安全警示规定，并对自己的安全负责。</td>
  </tr>
  <tr></tr>
</table>


<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第四章&nbsp;合同的变更与转让</th>
  </tr>
  <tr>
    <td align="left">第九条    　合同的变更</td>
  </tr>
  <tr>
    <td class="indent">1、旅行社与旅游者双方协商一致，可以变更本合同约定的内容，但应当以书面形式由双方签字确认。由此增加的旅游费用及给对方造成的损失，由变更提出方承担；由此减少的旅游费用，旅行社应当退还旅游者。</td>
  </tr>
  <tr>
    <td class="indent">2、行程开始前遇到不可抗力或者旅行社、履行辅助人已尽合理注意义务仍不能避免的事件的，双方经协商可以取消行程或者延期出行。取消行程的，按照本合同第十四条处理；延期出行的，增加的费用由旅游者承担，减少的费用退还旅游者。</td>
  </tr>
  <tr>
    <td class="indent">3、行程中遇到不可抗力或者旅行社、履行辅助人已尽合理注意义务仍不能避免的事件，影响旅游行程的，按以下方式处理：</td>
  </tr>
  <tr>
    <td class="indent2">（1）合同不能完全履行的，旅行社经向旅游者作出说明，旅游者同意变更的，可以在合理范围内变更合同，因此增加的费用由旅游者承担，减少的费用退还旅游者。</td>
  </tr>
  <tr>
    <td class="indent2">（2）危及旅游者人身、财产安全的，旅行社应当采取相应的安全措施，因此支出的费用，由旅行社与旅游者分担。</td>
  </tr>
  <tr>
     <td class="indent2">（3）造成旅游者滞留的，旅行社应采取相应的安置措施。因此增加的食宿费用由旅游者承担，增加的返程费用双方分担。</td>
  </tr>
  <tr>
    <td>第十条    　合同的转让</td>
  </tr>
  <tr>
    <td class="indent">旅游行程开始前，旅游者可以将本合同中自身的权利义务转让给第三人，旅行社没有正当理由的不得拒绝，并办理相关转让手续，因此增加的费用由旅游者和第三人承担。</td>
  </tr>
  <tr>
    <td class="indent">正当理由包括但不限于：对应原报名者办理的相关服务不可转让给第三人的；无法为第三人安排交通等情形的；旅游活动对于旅游者的身份、资格等有特殊要求的。</td>
  </tr>
  <tr>
    <td>第十一条    　不成团的安排</td>
  </tr>
  <tr>
    <td class="indent">当旅行社组团未达到约定的成团人数不能成团时，旅游者可以与旅行社就如下安排在本合同第二十三条中做出约定。</td>
  </tr>
  <tr>
    <td class="indent2">1、转团：旅行社可以在保证所承诺的服务内容和标准不降低的前提下，经事先征得旅游者书面同意，委托其他旅行社履行合同，并就受委托出团的旅行社违反本合同约定的行为先行承担责任，再行追偿。旅游者和受委托出团的旅行社另行签订合同的，本合同的权利义务终止。</td>
  </tr>
  <tr>
    <td class="indent2">2、延期出团和改变线路出团：旅行社经征得旅游者书面同意，可以延期出团或者改变其他线路出团，因此增加的费用由旅游者承担，减少的费用旅行社予以退还。需要时可以重新签订旅游合同。</td>
  </tr>
</table>


<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第五章&nbsp;合同的解除 </th>
  </tr>
  <tr>
    <td align="left">第十二条    　
    旅行社解除合同</p></td>
  </tr>
  <tr>
    <td class="indent">1、未达到约定的成团人数不能成团时，旅行社解除合同的，应当采取书面等有效形式。旅行社在行程开始前7日（按照出发日减去解除合同通知到达日的自然日之差计算，下同）以上（含第7日，下同）提出解除合同的，不承担违约责任，旅行社向旅游者退还已收取的全部旅游费用；旅行社在行程开始前7日以内（不含第7日，下同）提出解除合同的，除向旅游者退还已收取的全部旅游费用外，还应当按本合同第十七条第1款的约定，承担相应的违约责任。</td>
  </tr>
  <tr>
    <td class="indent">2、旅游者有下列情形之一的，旅行社可以解除合同：</td>
  </tr>
  <tr>
    <td class="indent2">（1）患有传染病等疾病，可能危害其他旅游者健康和安全的；</td>
  </tr>
  <tr>
    <td class="indent2">（2）&nbsp;携带危害公共安全的物品且不同意交有关部门处理的；</td>
  </tr>
  <tr>
    <td class="indent2">（3）从事违法或者违反社会公德的活动的；</td>
  </tr>
  <tr>
    <td class="indent2">（4）从事严重影响其他旅游者权益的活动，且不听劝阻、不能制止的；</td>
  </tr>
  <tr>
    <td class="indent2">（5）法律、法规规定的其他情形。</td>
  </tr>
  <tr>
    <td class="indent">旅行社因上述情形解除合同的，应当以书面等形式通知旅游者，按照本合同第十五条相关约定扣除必要的费用后，将余款退还旅游者。</td>
  </tr>
  <tr>
    <td>第十三条    　
      旅游者解除合同</p></td>
  </tr>
  <tr>
    <td class="indent">1、未达到约定的成团人数不能成团时，旅游者既不同意转团，也不同意延期出行或者改签其他线路出团的，旅行社应及时发出不能成团的书面通知，旅游者可以解除合同。旅游者在行程开始前7日以上收到旅行社不能成团通知的，旅行社不承担违约责任，向旅游者退还已收取的全部旅游费用；旅游者在行程开始前7日以内收到旅行社不能成团通知的，按照本合同第十七条第1款相关约定处理。</td>
  </tr>
  <tr>
    <td class="indent">2、除本条第1款约定外，在旅游行程结束前，旅游者亦可以书面等形式解除合同。旅游者在行程开始前7日以上提出解除合同的，旅行社应当向旅游者退还全部旅游费用；旅游者在行程开始前7日以内和行程中提出解除合同的，旅行社按照本合同第十五条相关约定扣除必要的费用后，将余款退还旅游者。</td>
  </tr>
  <tr>
    <td class="indent">3、旅游者未按约定时间到达约定集合出发地点，也未能在出发中途加入旅游团队的，视为旅游者解除合同，按照本合同第十五条相关约定处理。</td>
  </tr>
  <tr>
    <td>第十四条    　    因不可抗力或者已尽合理注意义务仍不能避免的事件解除合同</td>
  </tr>
  <tr>
    <td class="indent">因不可抗力或者旅行社、履行辅助人已尽合理注意义务仍不能避免的事件，影响旅游行程，合同不能继续履行的，旅行社和旅游者均可以解除合同；合同不能完全履行，旅游者不同意变更的，可以解除合同。合同解除的，旅行社应当在扣除已向地接社或者履行辅助人支付且不可退还的费用后，将余款退还旅游者。</td>
  </tr>
  <tr>
    <td>第十五条
    　    必要的费用扣除</td>
  </tr>
  <tr>
    <td class="indent">1、旅游者在行程开始前7日以内提出解除合同或者按照本合同第十二条第2款约定由旅行社在行程开始前解除合同的，按下列标准扣除必要的费用：</td>
  </tr>
  <tr>
    <td class="indent2">行程开始前6日至4日，按旅游费用总额的20%；&nbsp;</td>
  </tr>
  <tr>
    <td class="indent2">行程开始前3日至1日，按旅游费用总额的40%；</td>
  </tr>
  <tr>
    <td class="indent2">行程开始当日，按旅游费用总额的60%。</td>
  </tr>
  <tr>
    <td class="indent">2、在行程中解除合同的，必要的费用扣除标准为：</td>
  </tr>
  <tr>
    <td class="indent2">旅游费用&#215;行程开始当日扣除比例+（旅游费用-旅游费用&#215;行程开始当日扣除比例)&#247;旅游天数&#215;已经出游的天数。</td>
  </tr>
  <tr>
    <td class="indent">如按上述第1款或者第2款约定比例扣除的必要的费用低于实际发生的费用，旅游者按照实际发生的费用支付，但最高额不应当超过旅游费用总额。</td>
  </tr>
  <tr>
    <td class="indent">解除合同的，旅行社扣除必要的费用后，应当在解除合同通知到达日起5个工作日内为旅游者办结退款手续。</td>
  </tr>
  <tr>
    <td>第十六条
    　    
    旅行社协助旅游者返程及费用承担</p></td>
  </tr>
  <tr>
    <td class="indent">旅游行程中解除合同的，旅行社应协助旅游者返回出发地或者旅游者指定的合理地点。因旅行社或者履行辅助人的原因导致合同解除的，返程费用由旅行社承担；行程中按照本合同第十二条第2款，第十三条第2款约定解除合同的，返程费用由旅游者承担；按照本合同第十四条约定解除合同的，返程费用由双方分担。</td>
  </tr>
</table>


<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第六章&nbsp;违约责任 </th>
  </tr>
  <tr>
    <td align="left">第十七条    　旅行社的违约责任</td>
  </tr>
  <tr>
    <td class="indent">1、旅行社在行程开始前7日以内提出解除合同的，或者旅游者在行程开始前7日以内收到旅行社不能成团通知，不同意转团、延期出行和改签线路解除合同的，旅行社向旅游者退还已收取的全部旅游费用，并按下列标准向旅游者支付违约金：&nbsp;</td>
  </tr>
  <tr>
    <td class="indent2">行程开始前6日至4日，支付旅游费用总额10%的违约金；</td>
  </tr>
  <tr>
    <td class="indent2">行程开始前3日至1日，支付旅游费用总额15%的违约金；</td>
  </tr>
  <tr>
    <td class="indent2">行程开始当日，支付旅游费用总额20%的违约金。</td>
  </tr>
  <tr>
    <td class="indent2">如按上述比例支付的违约金不足以赔偿旅游者的实际损失，旅行社应当按实际损失对旅游者予以赔偿。</td>
  </tr>
  <tr>
    <td class="indent2">旅行社应当在取消出团通知或者旅游者不同意不成团安排的解除合同通知到达日起5个工作日内，为旅游者办结退还全部旅游费用的手续并支付上述违约金。</td>
  </tr>
  <tr>
    <td class="indent">2、旅行社未按合同约定提供服务，或者未经旅游者同意调整旅游行程（本合同第九条第3款规定的情形除外），造成项目减少、旅游时间缩短或者标准降低的，应当依法承担继续履行、采取补救措施或者赔偿损失等违约责任。</td>
  </tr>
  <tr>
    <td class="indent">3、旅行社具备履行条件，经旅游者要求仍拒绝履行本合同义务的，旅行社向旅游者支付旅游费用总额30%的违约金，旅游者采取订同等级别的住宿、用餐、交通等补救措施的，费用由旅行社承担；造成旅游者人身损害、滞留等严重后果的，旅游者还可以要求旅行社支付旅游费用一倍以上三倍以下的赔偿金。</td>
  </tr>
  <tr>
    <td class="indent">4、未经旅游者同意，旅行社转团、拼团的，旅行社应向旅游者支付旅游费用总额25%的违约金；旅游者解除合同的，旅行社还应向未随团出行的旅游者退还全部旅游费用，向已随团出行的旅游者退还尚未发生的旅游费用。如违约金不足以赔偿旅游者的实际损失，旅行社应当按实际损失对旅游者予以赔偿。</td>
  </tr>
  <tr>
    <td class="indent">5、旅行社有以下情形之一的，旅游者有权在旅游行程结束后30日内，要求旅行社为其办理退货并先行垫付退货货款，或者退还另行付费旅游项目的费用：</td>
  </tr>
  <tr>
    <td class="indent2">（1）旅行社以不合理的低价组织旅游活动，诱骗旅游者，并通过安排购物或者另行付费旅游项目获取回扣等不正当利益的；</td>
  </tr>
  <tr>
    <td class="indent2">（2）未经双方协商一致或者未经旅游者要求，旅行社指定具体购物场所或者安排另行付费旅游项目的。</td>
  </tr>
  <tr>
    <td class="indent">6、与旅游者出现纠纷时，旅行社应当采取积极措施防止损失扩大，否则应当就扩大的损失承担责任。</td>
  </tr>
  <tr>
    <td>第十八条    　
    旅游者的违约责任</p></td>
  </tr>
  <tr>
    <td class="indent">1、旅游者因不听从旅行社及其导游的劝告、提示而影响团队行程，给旅行社造成损失的，应当承担相应的赔偿责任。</td>
  </tr>
  <tr>
    <td class="indent">2、旅游者超出本合同约定的内容进行个人活动所造成的损失，由其自行承担。</td>
  </tr>
  <tr>
    <td class="indent">3、由于旅游者的过错，使旅行社、履行辅助人、旅游从业人员或者其他旅游者遭受损害的，旅游者应当赔偿损失。</td>
  </tr>
  <tr>
    <td class="indent">4、旅游者在旅游活动中或者在解决纠纷时，应采取措施防止损失扩大，否则应当就扩大的损失承担相应的责任。</td>
  </tr>
  <tr>
    <td class="indent">5、旅游者违反安全警示规定，或者对国家应对重大突发事件暂时限制旅游活动的措施、安全防范和应急处置措施不予配合，造成旅行社损失的，应当依法承担相应责任。</td>
  </tr>
  <tr></tr>
  <tr>
    <td>第十九条    　其他责任</td>
  </tr>
  <tr>
    <td class="indent">1、由于旅游者自身原因导致本合同不能履行或者不能按照约定履行，或者造成旅游者人身损害、财产损失的，旅行社不承担责任。</td>
  </tr>
  <tr>
    <td class="indent">2、旅游者在自行安排活动期间人身、财产权益受到损害的，旅行社在事前已尽到必要警示说明义务且事后已尽到必要救助义务的，旅行社不承担赔偿责任。</td>
  </tr>
  <tr>
    <td class="indent">3、由于第三方侵害等不可归责于旅行社的原因导致旅游者人身、财产权益受到损害的，旅行社不承担赔偿责任。但因旅行社不履行协助义务致使旅游者人身、财产权益损失扩大的，旅行社应当就扩大的损失承担赔偿责任。</td>
  </tr>
  <tr>
    <td class="indent">4、由于公共交通经营者的原因造成旅游者人身损害、财产损失依法应承担责任的，旅行社应当协助旅游者向公共交通经营者索赔。</td>
  </tr>
</table>



<table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="table_cont">
  <tr>
    <th height="40" align="center">第七章&nbsp;协议条款 </th>
  </tr>
  <tr>
    <td align="left">第二十条    　
      线路行程时间</p></td>
  </tr>
  <tr>
    <td class="indent">出发时间
      <input type="text" name="textfield26" id="textfield28" class="Basic_input input60">
      年
      <input type="text" name="textfield27" id="textfield29" class="Basic_input input30">
      月
      <input type="text" name="textfield28" id="textfield30" class="Basic_input input30">
      日
      <input type="text" name="textfield29" id="textfield31" class="Basic_input input30">
      时，
      结束时间
      <input type="text" name="textfield2" id="textfield2" class="Basic_input input60">
      年
      <input type="text" name="textfield2" id="textfield3" class="Basic_input input30">
      月
      <input type="text" name="textfield2" id="textfield32" class="Basic_input input30">
      日
      <input type="text" name="textfield2" id="textfield33" class="Basic_input input30">
      时，共
      <input type="text" name="textfield4" id="textfield4" class="Basic_input input60">
      天，饭店住宿
      <input type="text" name="textfield4" id="textfield4" class="Basic_input input60">
      夜。</td>
  </tr>
  <tr>
    <td>第二十一条    　
    旅游费用及支付（以人民币为计算单位）</p></td>
  </tr>
  <tr>
    <td class="indent">成人
      <input type="text" name="textfield5" id="textfield5" class="Basic_input input60">
      元/人；儿童（不满14岁的）
      <input type="text" name="textfield6" id="textfield6" class="Basic_input input60">
      元/人；其中，导游服务费
      <input type="text" name="textfield3" id="textfield34" class="Basic_input input60">
      元/人。</td>
  </tr>
  <tr>
    <td class="indent">导游费用合计
      <input type="text" name="textfield3" id="textfield34" class="Basic_input input120">
      元。 </td>
  </tr>
  <tr>
    <td class="indent">旅游费用支付方式：
      <input type="text" name="textfield3" id="textfield6" class="Basic_input input300">
      。</td>
  </tr>
  <tr>
    <td class="indent">旅游费用支付时间：
      <input type="text" name="textfield3" id="textfield5" class="Basic_input input300">
      。</td>
  </tr>
  
  <tr>
    <td>第二十二条    　
    人身意外伤害保险</p></td>
  </tr>
  <tr>
    <td class="indent">1、旅行社提示旅游者购买人身意外伤害保险；</td>
  </tr>
  <tr>
    <td class="indent">2、旅游者可以做以下选择：</td>
  </tr>
  <tr>
    <td class="indent"><label><input name="" type="checkbox" value="">委托旅行社购买（旅行社不具有保险兼业代理资格的，不得勾选此项）：保险产品名称
    <input type="text" name="textfield12" id="textfield12" class="Basic_input input300">　　　（投保的相关信息以实际保单为准）；</label></td>
  </tr>
  <tr>
    <td class="indent2"><label>
      <input type="checkbox" name="checkbox2" id="checkbox2">
      自行购买；</label></td>
  </tr>
  <tr>
    <td class="indent2"><label>
      <input type="checkbox" name="checkbox2" id="checkbox2">
      放弃购买。</label></td>
  </tr>
  
  <tr>
    <td>第二十三条    　成团人数与不成团的约定</td>
  </tr>
  <tr>
    <td class="indent">成团的最低人数
      <input type="text" name="textfield7" id="textfield7" class="Basic_input input60">
      人。</td>
  </tr>
  <tr>
    <td class="indent">如不能成团，旅游者是否同意按下列方式解决： </td>
  </tr>
  
  <tr>
    <td class="indent2">1.、
      <input type="text" name="textfield15" id="textfield15" class="Basic_input input60">
（同意或者不同意，打勾无效）旅行社委托
<input type="text" name="textfield16" id="textfield16" class="Basic_input input120">
旅行社履行合同；</td>
  </tr>
  <tr>
    <td class="indent2">2、<input type="text" name="textfield18" id="textfield18" class="Basic_input input60">
    （同意或者不同意，打勾无效）延期出团；</td>
  </tr>
  <tr>
    <td class="indent2">3、<input type="text" name="textfield19" id="textfield19" class="Basic_input input60">
（同意或者不同意，打勾无效）改变其他线路出团。</td>
  </tr>
  <tr>
    <td class="indent2">4.
      <input type="text" name="textfield8" id="textfield8" class="Basic_input input60">
（同意或者不同意，打勾无效）解除合同。</td>
  </tr>
  <tr>
    <td>第二十四条    　拼团约定</td>
  </tr>
  <tr>
    <td class="indent">旅游者
      <input type="text" name="textfield9" id="textfield9" class="Basic_input input60">    （同意或者不同意，打勾无效）采用拼团方式拼至
      <input type="text" name="textfield10" id="textfield10" class="Basic_input input120">    &nbsp;旅行社成团。</td>
  </tr>
  <tr>
    <td>第二十五条    　
    自愿购物和参加另行付费旅游项目约定</p></td>
  </tr>
  <tr>
    <td class="indent">1、旅游者可以自主决定是否参加旅行社安排的购物活动、另行付费旅游项目；</td>
  </tr>
  <tr>
    <td class="indent">2、旅行社可以在不以不合理的低价组织旅游活动、不诱骗旅游者、不获取回扣等不正当利益，且不影响其他旅游者行程安排的前提下，按照平等自愿、诚实信用的原则，与旅游者协商一致达成购物活动、另行付费旅游项目协议；</td>
  </tr>
  <tr>
    <td class="indent">3、购物活动、另行付费旅游项目安排应不与《行程单》冲突；</td>
  </tr>
  <tr>
    <td class="indent">4、地接社及其从业人员在行程中安排购物活动、另行付费旅游项目的，责任由订立本合同的旅行社承担；</td>
  </tr>
  <tr>
    <td class="indent">5、&nbsp;购物活动、另行付费旅游项目具体约定见《自愿购物活动补充协议》（附件3）、《自愿参加另行付费旅游项目补充协议》（附件4）。</td>
  </tr>
  <tr>
    <td>第二十六条    　争议的解决方式</td>
  </tr>
  <tr>
    <td class="indent">本合同履行过程中发生争议，由双方协商解决；亦可向合同签订地的旅游质监执法机构、消费者协会、有关的调解组织等有关部门或者机构申请调解。协商或者调解不成的，</p>
      按下列第
      <input type="text" name="textfield21" id="textfield21" class="Basic_input input60">
    种方式解决：</td>
  </tr>
  <tr>
    <td class="indent2">1、提交
      <input name="input10" type="text" class="Basic_input input200">
    仲裁委员会仲裁；</td>
  </tr>
  <tr>
    <td class="indent2">2、依法向人民法院起诉。</td>
  </tr>
  <tr>
    <td>第二十七条    　其他约定事项</td>
  </tr>
  <tr>
    <td class="indent">未尽事宜，经旅游者和旅行社双方协商一致，可以列入补充条款。（如合同空间不够，可以另附纸张，由双方签字或者盖章确认。）</td>
  </tr>
  <tr></tr>
  <tr>
    <td height="30" class="indent"><input name="input11" type="text" class="Basic_input input660"></td>
  </tr>
  <tr>
    <td height="30" class="indent"><input name="input12" type="text" class="Basic_input input660"></td>
  </tr>
  <tr>
    <td>第二十八条　合同效力 </td>
  </tr>
  <tr>
    <td>本合同一式
      <input type="text" name="textfield11" id="textfield11" class="Basic_input input30">
      份，双方各持
      <input type="text" name="textfield11" id="textfield35" class="Basic_input input30">
      ，具有同等法律效力，自双方当事人签字或者盖章之日起生效。 </td>
  </tr>
  
  <tr>
    <td>旅游者代表签字（盖章）：<input name="" type="text" class="Basic_input" style="width:206px;">旅行社盖章：<input name="" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>证件号码：
      <input name="" type="text" class="Basic_input input300">签约代表签字（盖章）：
<input name="" type="text" class="Basic_input input120"></td>
  </tr>
  <tr>
    <td>住　　址：<input name="input13" type="text" class="Basic_input input300">
    营业地址：      <input name="" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>联系电话：<input name="input14" type="text" class="Basic_input input300">
    联系电话：      <input name="" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>传　　真：<input name="input15" type="text" class="Basic_input input300">
传　　真：<input name="input15" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>邮　　编：<input name="input16" type="text" class="Basic_input input300">
邮　　编：<input name="input16" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>电子信箱：<input name="input17" type="text" class="Basic_input input300">
    电子信箱：<input name="input18" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td>签约日期：<input type="text" name="textfield22" id="textfield22" class="Basic_input input60">年<input type="text" name="textfield23" id="textfield23" class="Basic_input input60">月<input type="text" name="textfield24" id="textfield24" class="Basic_input input60">日<span style="padding-left:82px;"></span>签约日期：<input type="text" name="textfield25" id="textfield25" class="Basic_input input60">年<input type="text" name="textfield25" id="textfield26" class="Basic_input input60">月<input type="text" name="textfield25" id="textfield27" class="Basic_input input60">日</td>
  </tr>
  <tr>
    <td align="center">签约地点：<input name="input19" type="text" class="Basic_input input300"></td>
  </tr>
  <tr>
    <td align="center">旅行社监督、投诉电话：<input name="input20" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td align="center"><input name="input21" type="text" class="Basic_input input120">省<input name="input22" type="text" class="Basic_input input120">市旅游质监执法机构:</td>
  </tr>
  <tr>
    <td align="center">投诉电话：
    <input name="input23" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td align="center">电子邮箱：
    <input name="input24" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td align="center">地　　址：
    <input name="input25" type="text" class="Basic_input input200"></td>
  </tr>
  <tr>
    <td align="center">邮　　编：
    <input name="input26" type="text" class="Basic_input input200"></td>
  </tr>
   <tr>
        <td align="left">
            <hr />
            游客信息：
            <textarea id="ykxx" style="border: none; height: 20px; overflow-y: hidden;width:600px" class="Basic_input inputtext formsize800"
                cols=""></textarea>
        </td>
    </tr>
</table>
        </asp:PlaceHolder>
    </div>
    </form>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02">
                                        <form id="form2">
                                        <input type="hidden" id="saveHTML" name="saveHTML" />
                                        <a id="btnSave" href="javascript:;"><s class="baochun"></s>签订合同</a>
                                        </form>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02">
                                        <a id="a_print" href="javascript:;"><s class="baochun"></s>打印</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:PlaceHolder>

    <script type="text/javascript">

        $(function() {
            $("input,textarea").change(function() {
                $(this).attr("data-text", $(this).val())
            })
            $("input,textarea").each(function() {
                $(this).val($(this).attr("data-text"));
            })
            $("#ykxx").keyup(function(e) {
                e = window.event || e;
                if (e.keyCode == 13) {
                    $(this).css("height", $(this).height() + 15)
                }
            })//自增高
            $("#a_print").click(function() {
                $(this).hide();
                window.print();
            })
            $("#btnSave").click(function() {
                $("#saveHTML").val($("#form1").html());
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/printPage/ChyardContract.aspx?save=save&id=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                    data: $("#btnSave").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        tableToolbar._showMsg(ret.msg, function() { window.location.reload(); });
                    },
                    error: function() {
                        tableToolbar._showMsg("服务器繁忙，请稍后再试！");
                    }
                });
            })
        })
    </script>

</body>
</html>
