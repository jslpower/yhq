var FV_onBlur = {
    ValidType: "input,textarea,select",
    initValid: function(frm) {
        var self = this;
        var box = $(frm);
        if (box.length == 0) { alert("请指定容器!"); return false; };
        box.find(self.ValidType).each(function() {
            var _s = $(this);
            if (_s.attr("valid") !== undefined) {
                var fn = (function(a, b) {
                    return function() { self._validInput(a, b) };
                })(_s, box);
                self._addEvent(_s, fn);
            }
        })
    },
    /*private*/
    _validInput: function(ipt, frm, p) {
        if (p == null) p = 'errMsg_';
        var fv = new FormValid(frm);
        var msgs = ValiDatorForm.fvCheck(ipt, fv, frm.find(FV_onBlur.ValidType));
        var errmsgend = ipt.attr("errmsgend");
        if (errmsgend === undefined) {
            errmsgend = ipt.attr("id");
        }
        if (msgs.length > 0) {
            frm.find("span[id=" + p + errmsgend + "]").html(msgs.join(','));
        } else {
            frm.find("span[id=" + p + errmsgend + "]").html('');
        }
    },
    /*private*/
    _addEvent: function(elm, fn) {
        elm.blur(function() {
            fn();
        })
    }
};
var FormValid = function(frm) {
    this.frm = frm;
    this.errMsg = new Array();
    this.errName = new Array();
    this.required = function(inputObj) {
        if (inputObj.length == 0 || inputObj.val().trim() == "") {
            return false;
        }
        return true;
    },
    this.checked = function(inputObj) {
        return inputObj.attr("checked");
    },
    this.equal = function(inputObj, formElements) {
        var fstObj = inputObj;
        var sndObj = formElements.find("[name='" + inputObj.attr('eqaulName') + "']");
        if (fstObj.length > 0 && sndObj.length > 0) {
            if (fstObj.val() != sndObj.val()) {
                return false;
            }
        }
        return true;
    }
    this.gt = function(inputObj, formElements) {
        var fstObj = inputObj;
        var sndObj = formElements.find("[name='" + inputObj.attr('eqaulName') + "']");
        if (fstObj.length > 0 && sndObj.length > 0 && fstObj.val().trim() != '' && sndObj.val().trim() != '') {
            if (parseFloat(fstObj.val()) <= parseFloat(sndObj.val())) {
                return false;
            }
        }
        return true;
    }
    this.limitDate = function(inputObj) {
        if (inputObj.length > 0 && inputObj.val().length > 0) {
            var minDate = Date.parse(inputObj.attr('mindate').replace(/-/g, "/"));
            var currDate = Date.parse(inputObj.val().replace(/-/g, "/"));
            if (minDate - currDate > -1) {
                return false;
            }
            return true;
        }
        return true;
    }
    this.limit = function(inputObj) {
        if (inputObj.length > 0 && inputObj.val().length > 0) {
            var minv = parseInt(inputObj.attr('min'));
            var maxv = parseInt(inputObj.attr('max'));
            minv = minv || 0;
            maxv = maxv || Number.MAX_VALUE;
            return minv <= len && len <= maxv;
        }
        return true;
    }
    this.range = function(inputObj) {
        var val = parseFloat(inputObj.val());
        if (inputObj.val().length > 0) {
            var minv = parseFloat(inputObj.attr('min'));
            var maxv = parseFloat(inputObj.attr('max'));
            minv = minv || 0;
            maxv = maxv || Number.MAX_VALUE;
            return minv <= val && val <= maxv;
        }
        return true;
    },
	this.requiredSelected = function(selectObj, formElements) {
	    var minv = parseInt(selectObj.attr('min'));
	    var maxv = parseInt(selectObj.attr('max'));
	    minv = minv || 0;
	    maxv = maxv || Number.MAX_VALUE;

	    var selectedCount = 0, isSelected = false;
	    selectObj.find("option").each(function() {
	        isSelected = this.selected;
	        if (isSelected) {
	            selectedCount++;
	        }
	    })

	    return minv <= selectedCount && selectedCount <= maxv;
	},
	this.requiredRadioed = function(inputObj, formElements) {
	    var isChecked = false;
	    formElements.find("[name='" + inputObj.attr("name") + "']").each(function() {
	        if (this.checked) {
	            isChecked = true; return false;
	        }
	    })
	    return isChecked;
	},
	this.requireChecked = function(inputObj, formElements) {
	    var minv = parseInt(inputObj.attr('min'));
	    var maxv = parseInt(inputObj.attr('max'));
	    var arrayName = null;
	    var pos = inputObj.attr("name").indexOf('[');
	    if (pos != -1) {
	        arrayName = inputObj.attr("name").substr(0, pos);
	    }
	    minv = minv || 1;
	    maxv = maxv || Number.MAX_VALUE;
	    var checked = 0;
	    if (!arrayName) {
	        formElements.find("[name='" + inputObj.attr("name") + "']").each(function() {
	            if (this.checked) {
	                checked++;
	            }
	        })
	    } else {
	        formElements.find("input[type='checkbox']").each(function() {
	            if (this.checked == true && this.name.substring(0, arrayName.length) == arrayName) {
	                checked++;
	            }
	        })
	    }
	    return minv <= checked && checked <= maxv;
	}
    this.filter = function(inputObj) {
        var value = inputObj.val();
        var allow = inputObj.attr('allow');
        if (value.trim() != "") {
            return new RegExp("^.+\.(?=EXT)(EXT)$".replace(/EXT/g, allow.split(/\s*,\s*/).join("|")), "gi").test(value);
        }
        return true;
    }
    this.isNo = function(inputObj) {
        var value = inputObj.val();
        var noValue = inputObj.attr('noValue');
        return value != noValue;
    }
    this.isTelephone = function(inputObj) {
        var value = inputObj.val().trim();
        if (value == '') {
            return true;
        } else {
            if (!RegExps.isMobile.test(value) && !RegExps.isPhone.test(value)) {
                return false;
            }
        }
        return true;
    }
    this.checkReg = function(inputObj, reg, msg) {
        var value = inputObj.val().trim();
        if (value == '') {
            return true;
        } else {
            return reg.test(value);
        }
    }
    this.passed = function(errMode) {
        if (this.errMsg.length > 0) {
            if (errMode == "span") {
                FormValid.showError(this.errMsg, this.errName, this.frm);
            }
            if (errMode == "alert") {
                FormValid.alertError(this.errMsg);
            }
            if (errMode == "parent") {
                FormValid.parentAlertError(this.errMsg);
            }

            if (errMode == 'alertspan') {
                FormValid.alertError(this.errMsg);
                FormValid.showError(this.errMsg, this.errName, this.frm);
            }
            if (this.errName[0].indexOf('[') == -1) {
                frt = document.getElementById(this.errName[0]);
                if (frt != null) {
                    if (frt.type == 'text' || frt.type == 'password' || frt.type == 'select-one' || frt.type == "textarea") {
                        frt.focus();
                    }
                } else {
                    var obj = document.getElementById("errMsg_" + this.errName[0]);
                    if (obj != null) {
                        try { obj.focus(); } catch (e) { }
                    }
                }
            }
            return false;
        }
        else {
            return FormValid.succeed(this.frm.name);
        }
    }
    this.addErrorMsg = function(name, str) {
        this.errMsg.push(str);
        this.errName.push(name);
    }
    this.addAllName = function(name) {
        FormValid.allName.push(name);
    }
};
FormValid.allName = new Array();
FormValid.alertError = function(errMsg) {
    var msg = "";
    for (i = 0; i < errMsg.length; i++) {
        msg += "- " + errMsg[i] + "<br />";
    }
    setTimeout(function() { tableToolbar._showMsg(msg); }, 300);
};
FormValid.parentAlertError = function(errMsg) {
    var msg = "";
    for (i = 0; i < errMsg.length; i++) {
        msg += "- " + errMsg[i] + "<br />";
    }
    setTimeout(function() { parent.tableToolbar._showMsg(msg); }, 300);
};
FormValid.showError = function(errMsg, errName, formName) {
    for (var key = 0; key < errMsg.length; key++) {

        var obj = formName.find("span[id$=errMsg_" + errName[key] + "]");
        if (obj.length == 0) {
            obj = $('#errMsg_' + errName[key]);
        }
        obj.html(errMsg[key]);
    }
}
FormValid.succeed = function() {
    return true;
};
var ValiDatorForm = {
    /*
    frm【FormValid对象】，
    errPatten参数说明【alert表示提示信息使用弹框，span表示提示信息在span标签显示】，
    model【默认为true,验证元素valid中所有的验证表达式，设置为false时,当元素valid第一个验证表达式不通过时，不继续其他的验证，跳转到下一个元素 】.
    */
    model: true,
    validator: function(frm, errPattern, model) {
        frm = $(frm);
        this.ClearerrMsg(frm);
        var formElements = frm.find(FV_onBlur.ValidType);
        var fv = new FormValid(frm);
        FormValid.allName = new Array();
        formElements.each(function() {
            var msgs = ValiDatorForm.fvCheck($(this), fv, formElements);
            var errMsgEnd = $(this).attr("errmsgend");
            if (errMsgEnd == null) {
                errMsgEnd = $(this).attr("id");
            }
            if (msgs.length > 0) {
                for (var j = 0; j < msgs.length; j++) {
                    fv.addErrorMsg(errMsgEnd, msgs[j]);
                }
            }
        })
        return fv.passed(errPattern);
    },
    ClearerrMsg: function(frm) {
        var errMsgEnd;
        frm.find(FV_onBlur.ValidType).each(function() {
            var _s = $(this);
            errMsgEnd = _s.attr("errmsgend");
            if (!errMsgEnd) {
                errMsgEnd = _s.attr("id");
            }
            var obj = $('#errMsg_' + errMsgEnd);
            if (obj.length > 0) {
                obj.html("");
                obj.unbind("blur");
            }
        })
    },
    fvCheck: function(e, fv, formElements) {
        var validType = e.attr('valid');
        var errorMsg = e.attr('errmsg');
        if (!errorMsg) {
            errorMsg = '';
        }
        if (validType === undefined) { return [] };
        fv.addAllName(e.attr("id"));
        var vts = validType.split('|');
        var ems = errorMsg.split('|');
        var r = [];
        for (var j = 0; j < vts.length; j++) {
            var curValidType = vts[j];
            var curErrorMsg = ems[j];
            var validResult;
            switch (curValidType) {
                case 'isNumber':
                case 'isEmail':
                case 'isPhone':
                case 'isMobile':
                case 'isIdCard':
                case 'isMoney':
                case 'isZip':
                case 'isQQ':
                case 'isInt':
                case 'isEnglish':
                case 'isChinese':
                case 'isUrl':
                case 'notHttpUrl':
                case 'isDate':
                case 'isTime':
                case 'RegInteger':
                case 'PositiveIntegers':
                case 'isTel':
                case 'IsDecimalTwo':
                case 'isPIntegers':
                case 'IsDecimalOne':
                    validResult = fv.checkReg(e, RegExps[curValidType], curErrorMsg);
                    break;
                case 'regexp':
                    validResult = fv.checkReg(e, new RegExp(e.getAttribute('regexp'), "g"), curErrorMsg);
                    break;
                    validResult = fv.checkReg(e, new RegExp(e.getAttribute('regexp'), "g"), curErrorMsg);
                    break;
                case 'custom':
                    if (e.attr("custom").indexOf(".") == -1) {
                        validResult = window[e.attr("custom")](e, formElements);
                    } else {
                        validResult = window[e.attr("custom").split('.')[0]][e.attr("custom").split('.')[1]](e, formElements);
                    }
                    break;
                default:
                    validResult = fv[curValidType](e, formElements);
                    break;
            }
            if (!validResult) r.push(curErrorMsg);
            if (!validResult && ValiDatorForm.model == false) {
                break;
            }
        }
        return r;
    }
};
String.prototype.trim = function() {
    return this.replace(/^\s*|\s*$/g, "");
};
var RegExps = function() { };
RegExps.isNumber = /^[-\+]?\d+(\.\d+)?$/;
RegExps.isEmail = /([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)/;
RegExps.isPhone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-?)?[1-9]\d{6,7}(\-\d{1,4})?$/;
RegExps.isMobile = /^(13|15|18|14)\d{9}$/;
RegExps.isIdCard = /(^\d{15}$)|(^\d{17}[0-9Xx]$)/;
RegExps.isMoney = /^\d+(\.\d+)?$/;
RegExps.isZip = /^[1-9]\d{5}$/;
RegExps.isQQ = /^[1-9]\d{4,10}$/;
RegExps.isInt = /^[-\+]?\d+$/;
RegExps.isEnglish = /^[A-Za-z]+$/;
RegExps.isChinese = /^[\u0391-\uFFE5]+$/;
RegExps.notHttpUrl = /[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
RegExps.isUrl = /^http[s]?:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
RegExps.isDate = /^\d{4}-\d{1,2}-\d{1,2}$/;
RegExps.isTime = /^\d{4}-\d{1,2}-\d{1,2}\s\d{1,2}:\d{1,2}:\d{1,2}$/;
RegExps.RegInteger = /^[0-9]+$/;
RegExps.PositiveIntegers = /^[1-9]+$/;
RegExps.IsDecimalTwo = /^[0-9]+([.]\d{1,2})?$/;
RegExps.IsDecimalOne = /^[0-9]+([.]\d{1})?$/;
//Phone code or Mobile Code
RegExps.isTel = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-?)?[1-9]\d{6,7}(\-\d{1,4})?$|^(13|15|18|14)\d{9}$/;
RegExps.isPIntegers = /^[1-9]\d*$/;
