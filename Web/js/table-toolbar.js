var tableToolbar = {
    init: function(options) {
        this.options = jQuery.extend(tableToolbar.DEFAULTS, options || {});

        this.container = $(this.options.tableContainerSelector);


        if (this.options.allSelectedCheckBoxSelector == "") {
            if (this.options.isHaveAllSelectedFun) {
                this.allSelectedBox = this.container.find("input[type='checkbox']").eq(0);
            } else {
                this.allSelectedBox = $([]);
            }
        } else {
            this.allSelectedBox = $(this.options.allSelectedCheckBoxSelector);
        }

        if (this.options.checkBoxSelector == "") {
            if (this.options.isHaveAllSelectedFun) {
                this.checkboxList = this.container.find("input[type='checkbox']:gt(0)");
            } else {
                this.checkboxList = this.container.find("input[type='checkbox']");
            }
        } else {
            this.checkboxList = $(this.options.checkBoxSelector);
        }

        this._initSelectedFun();
        this._initButtonFun();
        this._initTableStyle();
    },
    /* public */
    getSelectedColCount: function() {
        var count = 0;
        this.checkboxList.each(function() {
            if (this.checked) {
                count++;
            }
        });

        return count;
    },
    getSelectedCols: function() {
        var cols = [];
        this.checkboxList.each(function() {
            if (this.checked) {
                cols.push($(this).closest("tr"));
            }
        });

        return cols;
    },
    /* private */
    _initSelectedFun: function() {
        var self = this;
        if (this.allSelectedBox.length > 0) {
            this.allSelectedBox.click(function() {
                var check = this.checked;
                if (check) {
                    self.checkboxList.attr("checked", "checked");
                    self.container.find("tr").addClass("selected");
                } else {
                    self.checkboxList.removeAttr("checked");
                    self.container.find("tr").removeClass("selected");
                }
            });
        }

        this.checkboxList.click(function() {
            var check = this.checked;
            if (check) {
                self.allSelectedBox.attr("checked", "checked");
                $(this).closest("tr").addClass('selected');
            } else {
                $(this).closest("tr").removeClass('selected');
            }
        });
    },
    _initButtonFun: function() {
        var self = this;
        //this.add = $(this.add_selector);
        this.updateB = $(this.options.update_selector);
        if (this.updateB.length > 0) {
            this.updateB.click(function() {
                var count = self.getSelectedColCount();
                var isSucess = false;
                var msg;
                if (count == 0) {
                    isSucess = false;
                    msg = self.options.update_msg1.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else if (count > 1) {
                    isSucess = false;
                    msg = self.options.update_msg2.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else {
                    isSucess = true;
                }

                if (isSucess) {
                    if (self.options.updateCallBack != null) {
                        self.options.updateCallBack(self.getSelectedCols());
                        return false;
                    }
                } else {
                    //tip msg.
                    self._showMsg(msg);
                    return false;
                }
            });
        }

        this.deleteB = $(this.options.delete_selector);
        if (this.deleteB.length > 0) {
            this.deleteB.click(function() {
                var count = self.getSelectedColCount();
                var isSucess = false;
                var msg;
                if (count == 0) {
                    msg = self.options.delete_msg.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else {
                    isSucess = true;
                }



                if (isSucess) {
                    var rows = self.getSelectedCols();
                    if (self.IsHandleElse == "false") {
                        var msgList = new Array();
                        for (var i = 0; i < rows.length; i++) {
                            if (rows[i].find("input[type='checkbox']").val() != "on") {
                                if (rows[i].find("input[name='ItemUserID']").val() != self.UserID) {
                                    msgList.push("你没有当前选中项中第" + (i + 1) + "行数据的操作权限!");
                                }
                            }
                        }
                        if (msgList.length > 0) {
                            self._showMsg(msgList.join("<br />"));
                            return false;
                        }
                    }
                    var confirmMsg = self._formatMsg(self.options.delete_confirm_msg);
                    var _html = '<div style="padding: 10px 0 20px 10px;cursor: default;"><h2  style="margin:10px 5px;"><img src="/images/y-tanhao.gif" style=" vertical-align:middle; margin-right:5px;" />  {{msg}}</h2> <input type="button" id="BLOCKUI_YES" value="确 定" style="width:64px; height:24px; border:0 none;background:url(/images/cx.gif);" /><input type="button" onclick="$.unblockUI();return false;"  value="取消" " style="width:64px; height:24px; border:0 none;  margin-left:20px; background:url(/images/cx.gif);" /> </div>';
                    $.blockUI({
                        message: _html.replace(/{{msg}}/, confirmMsg),
                        css: { backgroundColor: "#E9F4F9", borderColor: "#00446b", borderWidth: '1px', cursor: "pointer", color: "#ed0000", width: '375px' }
                    });
                    $("#BLOCKUI_YES").click(function() {
                        $.unblockUI();
                        if (self.options.deleteCallBack != null) {
                            self.options.deleteCallBack(rows);
                            return false;
                        }
                    });
                    return false;

                } else {
                    //tip msg. 
                    self._showMsg(msg);
                    return false;
                }
            });
        }

        this.cancel = $(this.options.cancel_selector);
        if (this.cancel.length > 0) {
            this.cancel.click(function() {
                var count = self.getSelectedColCount();
                var isSucess = false;
                var msg;
                if (count == 0) {
                    msg = self.options.cancel_msg.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else {
                    isSucess = true;
                }

                if (isSucess) {
                    var rows = self.getSelectedCols();
                    if (self.IsHandleElse == "false") {
                        var msgList = new Array();
                        for (var i = 0; i < rows.length; i++) {
                            if (rows[i].find("input[type='checkbox']").val() != "on") {
                                if (rows[i].find("input[type='hidden'][name='ItemUserID']").val() != self.UserID) {
                                    msgList.push("你没有当前选中项中第" + (i + 1) + "行数据的操作权限!");
                                }
                            }
                        }
                        if (msgList.length > 0) {
                            self._showMsg(msgList.join("<br />"));
                            return false;
                        }
                    }
                    if (self.options.cancelCallBack != null) {
                        self.options.cancelCallBack(rows);
                        return false;
                    }
                } else {
                    //tip msg.
                    self._showMsg(msg);
                    return false;
                }
            });
        }

        this.copy = $(this.options.copy_selector);
        if (this.copy.length > 0) {
            this.copy.click(function() {
                var count = self.getSelectedColCount();
                var isSucess = false;
                var msg;
                if (count == 0) {
                    isSucess = false;
                    msg = self.options.copy_msg1.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else if (count > 1) {
                    isSucess = false;
                    msg = self.options.copy_msg2.replace(new RegExp(self.options.objectNamePlaceHolder, "gm"), self.options.objectName);
                } else {
                    isSucess = true;
                }

                if (isSucess) {
                    if (self.options.copyCallBack != null) {
                        self.options.copyCallBack(self.getSelectedCols());
                        return false;
                    }
                } else {
                    //tip msg.
                    self._showMsg(msg);
                    return false;
                }
            });
        }
        //other buttons.
        for (var i = 0; i < this.options.otherButtons.length; i++) {
            var button = this.options.otherButtons[i];
            var jButton = $(button.button_selector);
            if (jButton.length > 0) {
                var fun = (function() {
                    var index = i;
                    return function() {
                        var button = self.options.otherButtons[index];
                        var count = self.getSelectedColCount();
                        var isSucess = false;
                        var msg = button.msg;
                        var msg2 = button.msg2; ;
                        if (self.sucessRule[button.sucessRulr] == 1) {
                            if (count == 1) {
                                isSucess = true;
                            }
                        } else if (self.sucessRule[button.sucessRulr] == 2) {
                            if (count > 0) {
                                isSucess = true;
                            }
                        }

                        if (isSucess) {
                            if (button.buttonCallBack != null) {
                                button.buttonCallBack(self.getSelectedCols());
                                return false;
                            }
                        } else {
                            //tip msg.
                            if (count > 1 && msg2) {
                                self._showMsg(msg2);
                            } else
                                self._showMsg(msg);
                            return false;
                        }
                    };
                })();
                jButton.click(fun);
            }
        }
    },
    _showMsg: function(msg, callbackfun) {
        var self = this;
        $.blockUI({
            message: self._dialogHtml.replace(/{{msg}}/, msg),
            showOverlay: false,
            centerX: true,
            centerY: false,
            css: { top: '170px', backgroundColor: "#FEF7CB", borderColor: "#D59228", borderWidth: '1px', cursor: "pointer", color: "#ed0000", "z-index": "9999" },
            timeout: 2500,
            onUnblock: callbackfun
        });

    },
    ShowConfirmMsg: function(msg, callbackfun, callbackfun2) {
        var confirmMsg = msg;
        var _html = '<div style="padding: 10px 0 20px 10px;cursor: default;"><h1 style="margin:10px 5px;font-size: 18px;"><img src="/images/y-tanhao.gif" style=" vertical-align:middle; margin-right:5px;" />  {{msg}}</h1><input type="button" id="BLOCKUI_YES" value="确 定" style="width:64px; height:24px; border:0 none;background:url(/images/cx.gif);" /><input type="button" id="BLOCKUI_NO" value="取消" " style="width:64px; height:24px; border:0 none;  margin-left:20px; background:url(/images/cx.gif);" />  </div>';
        $.blockUI({
            message: _html.replace(/{{msg}}/, confirmMsg),
            css: { backgroundColor: "#E9F4F9", borderColor: "#00446b", borderWidth: '1px', cursor: "pointer", color: "#ed0000", width: '375px' }
        });
        $("#BLOCKUI_YES").click(function() {
            $.unblockUI();
            if (callbackfun != null) {
                callbackfun();
                return false;
            }
        });
        $("#BLOCKUI_NO").click(function() {
            $.unblockUI();
            if (callbackfun2) {
                callbackfun2();
                return false;
            }
        })
        return false;
    },

    _formatMsg: function(msg) {
        return msg.replace(new RegExp(this.options.objectNamePlaceHolder, "gm"), this.options.objectName);
    },
    _dialogHtml: '<h3 style="padding:20px 0">{{msg}}</h3>',
    _initTableStyle: function() {
        //隔行,滑动,点击 变色.+ 单选框选中的行 变色:        
        //this.container.find("tr:nth-child(even)").addClass('odd');        
        //this.container.find("tbody>tr:even").addClass('odd');
        //this.container.find("tr:even").addClass('odd');
        this.container.children().children("tr:even").addClass('odd');
        this.container.find("tr").hover(
			function() { $(this).addClass('highlight'); },
			function() { $(this).removeClass('highlight'); }
		);
        // 如果单选框默认情况下是选择的，变色.
        //$('#liststyle input[type="radio"]:checked').parents('tr').addClass('selected');

    },
    sucessRule: [0, 1, 2], /* 0index作为占位存在不起作用，1index代表只能选中一个,2index代表可以选择多个  */
    DEFAULTS: {
        tableContainerSelector: "#liststyle",
        allSelectedCheckBoxSelector: "",
        checkBoxSelector: "",
        isHaveAllSelectedFun: true,
        objectName: "列",
        objectNamePlaceHolder: "{{colName}}",
        add_selector: ".toolbar_add",
        update_selector: ".toolbar_update",
        delete_selector: ".toolbar_delete",
        cancel_selector: ".toolbar_cancel",
        copy_selector: ".toolbar_copy",


        /* example */
        /*
        otherButton:[{
        button_selector:'',
        sucessRulr:1
        msg:'fssdsdfd',
        buttonCallBack:function(){}
        }]
			
    */
        otherButtons: [],

        update_msg1: "未选中任何{{colName}}",
        update_msg2: "只能选择一条{{colName}} 进行修改",
        delete_msg: "未选中任何{{colName}}",
        delete_confirm_msg: "确定删除选中的{{colName}}？删除后不可恢复！",
        cancel_msg: "未选中任何{{colName}}",
        copy_msg1: "未选中任何{{colName}}",
        copy_msg2: "只能选择一条 {{colName}} 进行复制",
        stop_msg1: "确定停用选中的{{colName}}？",
        start_msg1: "确定启用选中的{{colName}}？",
        blacklist_msg1: "确定选中的{{colName}}要加入黑名单吗？",
        updateCallBack: null,
        deleteCallBack: null,
        cancelCallBack: null,
        copyCallBack: null
    },
    //转换int值，转换失败返回0
    getInt: function(o) {
        if (isNaN(o)) return 0;

        if (parseInt(o)) {
            return parseInt(o);
        }

        return 0;
    },
    //转换float值，转换失败返回0,保留二位小数（四舍五入）
    getFloat: function(o) {
        if (isNaN(o)) return 0;

        if (parseFloat(o)) {
            var _v = parseFloat(o) * 100;
            _v = _v / 100;

            return Math.round(parseFloat(_v.toFixed(2)) * 100) / 100;
        }

        return 0;
    },
    //精确两位小数的计算a=value,b=value ,c= + || - || * || /
    calculate: function(a, b, c) {
        var _v = 0;
        switch (c) {
            case "+":
                _v = (this.getFloat(a) * 100 + this.getFloat(b) * 100) / 100;
                break;
            case "-":
                _v = (this.getFloat(a) * 100 - this.getFloat(b) * 100) / 100;
                break;
            case "*":
                _v = (this.getFloat(a) * this.getFloat(b) * 100) / 100;
                break;
            case "/":
                b = this.getFloat(b);
                if (b == 0) { return 0; }
                _v = (this.getFloat(a) / this.getFloat(b) * 100) / 100;
                break;
            default: _v = 0;
        }

        return this.getFloat(_v);
    },
    //登录公司编号
    CompanyID: top.tableToolbar ? top.tableToolbar.CompanyID : "",
    //登录人编号
    UserID: top.tableToolbar ? top.tableToolbar.UserID : "",
    //数据操作模式
    IsHandleElse: true,
    errorMsg: "连接服务器失败，请刷新后再试!"
};

jQuery.newAjax = function(options, noneedcheck) {
    var dataType = "text";
    if (options.dataType) {
        dataType = options.dataType;
    }
    var isPostType = false;
    if (options.type) {
        if (options.type.toUpperCase() == "POST") {
            isPostType = true;
        }
    }
    var orisucess;
    if (options.success) {
        orisucess = options.success;
    }
    options.success = function(result) {
        var isLogin = false, isCheck = false;
        if (dataType == "text") {
            if (result != "{Islogin:false}") {
                isLogin = true;
            }
            if (result != "{isCheck:false}") {
                isCheck = true;
            }
        } else {
            if (result.Islogin === undefined) {
                isLogin = true;
            }
            if (result.isCheck === undefined) {
                isCheck = true;
            }
        }
        if (isLogin === false) {
            alert('对不起你未登录，请登录！');
            top.window.location.href = "/login.aspx?returnurl=" + encodeURIComponent(window.location.href);
            return false;
        } else if (isCheck === false) {
            alert("对不起，您还未通过审核，不能进行操作！");
            return false;
        } else {
            if (orisucess) {
                orisucess(result);
            }
        }
    };
    jQuery.ajax(options);
};
/*
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//滚动条插件，使用方法:jquery容器.moveScroll({参数}); by 田想兵 2011.9.5
//options{  speed:滚动速率,step:步长速度 }
//调用示例$(".content").moveScroll();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
*/
(function($) {
    $.fn.moveScroll = function(options) {
        var settings = { speed: 40, step: 10 };
        if (options) $.extend(settings, options);
        var container = $(this);
        var table = container.children();
        var isActive = false;
        $("body").append('<div style="width:50px;position:absolute;display:none;font-size:20px;font-weight:bolder; background-color:gray;filter:alpha(opacity=50);opacity: 0.5; -moz-opacity:0.5;cursor:pointer;" id="scrollBar">></div>');
        var tmp;
        var bar = $("#scrollBar");
        bar.css("height", container.height());
        container.mouseover(function() {
            $(this).bind("mousemove", function(evt) {
                //console.log(evt.clientX);
                //console.log(container.offset().left);
                var pos = evt.clientX - container.offset().left;
                if (pos > container.width() - 50 && !isActive && container.scrollLeft() < table.get(0).clientWidth - container.width()) {
                    bar.html(">>");
                    showBar(container.width() + container.offset().left - 50, container.offset().top);
                    bar.attr("pos", "right");
                    if (isActive)
                        bar.bind("click", function() {
                            var temp = parseInt(container.scrollLeft()) + settings.step;
                            //console.log(temp);
                            //container.scrollLeft(temp);
                            container.animate({ scrollLeft: temp }, settings.speed);
                        });
                } else {
                    hideBar();
                }
                if (pos < 50 && !isActive && container.scrollLeft() > 0) {
                    showBar(container.offset().left, container.offset().top);
                    bar.html(" <<");
                    bar.attr("pos", "left");
                    if (isActive)
                        bar.bind("click", function() {
                            var temp = parseInt(container.scrollLeft()) - settings.step;
                            //console.log(temp);
                            temp = temp < 0 ? 0 : temp;
                            //container.scrollLeft(temp);
                            container.animate({ scrollLeft: temp }, settings.speed);
                        });
                }
                //console.log(container.width());
                //console.log(table.get(0).clientWidth);
            });
        }).mouseout(function() {
            $(this).unbind("mousemove");
        });
        container.scroll(function() {
            //console.log(container.scrollLeft());
            if ((container.scrollLeft() >= table.get(0).clientWidth - container.width() || container.scrollLeft() == 0) && isActive) {
                hideBar();
                bar.unbind("click");
            }
        });
        bar.mouseout(hideBar);
        function showBar(pos, top) {
            bar.show().css("left", pos).css("top", top);
            isActive = true;
        }
        function hideBar() {
            isActive = false;
            bar.hide();
            bar.unbind("click");
            if (tmp)
                clearInterval(tmp);
        }
        bar.mousedown(function(e) {
            //console.log("down");
            tmp = setInterval(function() {
                var tempx = 0
                switch (bar.attr("pos")) {
                    case "left":
                        {
                            tempx = parseInt(container.scrollLeft()) - 10;
                            //console.log(temp);
                            tempx = tempx < 0 ? 0 : tempx;
                        } break;
                    case "right":
                        {
                            tempx = parseInt(container.scrollLeft()) + 10;
                        } break;
                }
                //console.log(tempx);
                container.scrollLeft(tempx);
            }, 40);
        }).mouseup(function() {
            if (tmp)
                clearInterval(tmp);
        });
    }
})(jQuery);
/*
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//自动添加行，使用方法:jquery容器.autoAdd({参数}); by 田想兵 2011.9.7
//options{tempRowClass:"模版行样式", addButtonClass:"添加按钮样式",delButtonClass:"删除按钮样式"}
//调用示例$(".content").autoAdd();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
*/
(function($) {
    $.fn.autoAdd = function(options) {
        var settings = { changeInput: $("#input"), tempRowClass: "tempRow", min: 1, max: 90, addButtonClass: "addbtn", delButtonClass: "delbtn", addCallBack: null, delCallBack: null, indexClass: "index", insertClass: "insertbtn", moveUpClass: "moveupbtn", moveDownClass: "movedownbtn", upCallBack: null, downCallBack: null, delStartCall: null };
        if (options) $.extend(settings, options);
        var content = this;
        var count = content.find("." + settings.tempRowClass).length;
        settings.changeInput.change(function() {
            var ival = tableToolbar.getInt(this.value);
            if (ival > 0) {
                if (ival > settings.max || ival < settings.min) {
                    tableToolbar._showMsg("请输入大于等于 " + settings.min + " 并且小于等于 " + settings.max + " 的数!");
                    if (ival > settings.max)
                        this.value = settings.max;
                    if (ival < settings.min)
                        this.value = settings.min;
                    $(this).change();
                } else {
                    addRow($(this).val());
                }
            } else {
                tableToolbar._showMsg("请输入有效的整数！");
                $(this).val("");
                $(this).focus();
            }
        });
        content.find("." + settings.tempRowClass).each(function() {
            $(this).find(".richText,input").each(function() {
                if ($(this).attr("id").length == 0)
                    $(this).attr("id", "txt_" + Math.round(Math.random() * new Date().getTime()))

            });
        });
        function addRow(num, isInsert, target) {
            //console.log(temp);
            //var strTemp = "";
            for (var i = 0; i < num - count; i++) {
                var temp = content.find("." + settings.tempRowClass).first().clone(true);
                temp.find("input:not(:checkbox,:radio)").val("");
                temp.find("select").val("-1");
                temp.find("textarea").val("");
                temp.find(":checkbox").attr("checked", false);
                temp.attr("id", "");
                temp.find("input,tr,textarea,select,:checkbox,tbody").attr("id", "").removeAttr("disabled");
                if (temp.find(".ke-container").length > 0) {
                    temp.find(".ke-container").remove();
                }
                temp.find(".richText,input").each(function() {
                    $(this).attr("id", "txt_" + Math.round(Math.random() * new Date().getTime()))
                    $(this).show();
                });

                temp.find("span[class='planshopspan']").remove();
                temp.find("td[class='imgtd']").html("");


                if (isInsert) {
                    temp.insertBefore(target.closest("." + settings.tempRowClass));
                } else {
                    content.append(temp);
                }
                if (settings.addCallBack)
                    settings.addCallBack(temp);
            }
            if (num < count) {
                for (var j = count - 1; j >= num; j--) {
                    if (content.children().eq(j + 1).length > 0) {
                        delRow(content.children().eq(j + 1));
                    }
                }
            } else {
                //content.append($(strTemp));

            }
            count = content.find("." + settings.tempRowClass).length;
            settings.changeInput.val(count);
            sumIndex();
            showhideBtn();
            //console.log(strTemp);
        };
        function showhideBtn() {
            content.find("." + settings.tempRowClass).find("." + settings.moveUpClass + ",." + settings.moveDownClass).show();
            content.find("." + settings.tempRowClass).first().find("." + settings.moveUpClass).hide();
            content.find("." + settings.tempRowClass).last().find("." + settings.moveDownClass).hide();
        }
        content.find("." + settings.addButtonClass).bind("click", function() {
            //console.log(count);
            if (count >= settings.max) {
                tableToolbar._showMsg("最多只能添加 " + settings.max + " 行记录!");
            } else {
                addRow(count + 1);
            }
            return false;
        });
        content.find("." + settings.insertClass).bind("click", function() {
            if (count >= settings.max) {
                tableToolbar._showMsg("最多只能添加 " + settings.max + " 行记录!");
            } else {
                addRow(count + 1, true, $(this));
            }
            return false;
        });
        content.find("." + settings.moveUpClass).bind("click", function() {
            var tr = $(this).closest("." + settings.tempRowClass);
            tr.insertBefore($(this).closest("." + settings.tempRowClass).prev("." + settings.tempRowClass));
            showhideBtn();
            sumIndex();
            if (settings.upCallBack) { settings.upCallBack(tr); }
            return false;
        });
        content.find("." + settings.moveDownClass).bind("click", function() {
            var tr = $(this).closest("." + settings.tempRowClass);
            tr.insertAfter($(this).closest("." + settings.tempRowClass).next("." + settings.tempRowClass));
            showhideBtn();
            sumIndex();
            if (settings.downCallBack) { settings.downCallBack(tr) }
            return false;
        });
        content.find("." + settings.delButtonClass).bind("click", function() {
            //console.log(count);
            count = content.find("." + settings.tempRowClass).length;
            if (count > settings.min) {
                count--;
                delRow($(this).closest("." + settings.tempRowClass));
            } else {
                tableToolbar._showMsg("需至少保留 " + settings.min + " 行记录!");
            }
            return false;
        });
        function delRow(row) {
            if (settings.delStartCall) {
                settings.delStartCall(row);
            }

            if (row.find("object").length > 0) {
                try {
                    row.find("object").remove();
                } catch (e) {

                }
            }
            row.remove();
            count = content.find("." + settings.tempRowClass).length;
            settings.changeInput.val(count);
            if (settings.delCallBack)
                settings.delCallBack();
            showhideBtn();
            sumIndex();
        }
        function sumIndex() {
            content.find("." + settings.indexClass).each(function(index, domEle) {
                $(this).html(index + 1);
            });
        }
        showhideBtn();
    }
})(jQuery);
$(function() {
    $(".autoAdd").each(function() {
        $(this).autoAdd();
    });
});
function querystring(uri, val) {
    var re = new RegExp("" + val + "\=([^\&\?]*)", "ig");
    return ((uri.match(re)) ? (uri.match(re)[0].substr(val.length + 1)) : null);
}
/****
选择弹窗    by戴银柱
newToobar.init({ className: ".select", hideName: "hide", showName: "text", iframeUrl: "test.aspx" })
****/
var newToobar = {
    init: function(options) {
        if (options.box == undefined) {
            tableToolbar._showMsg("指定BOX");
            return;
        }
        var _self = this;
        $(options.box).find("a[class='" + options.className + "']").each(function() {
            var _f = new _self.funt();
            $.extend(_f.options, options);
            _f.init(this);
        });
    },
    funt: function() {
        this.options = {
            box: null,
            className: "xuanyong",  //选用按钮className
            hideName: null,           //隐藏域name
            showName: null,           //文本框name
            iframeUrl: null,          //跳转地址,为空则取a标签的href值
            title: null,              //弹窗标题
            width: null,           //弹窗宽度
            height: null,          //弹窗高度
            para: null,               //参数{a:'',b:''}
            callFastFun: null,       //弹窗前执行的的函数
            callBackFun: null       //回调函数返回参数obj:{value:"",text:""}
        };
        this.click = function(args) {
            var win = top || window;
            win.Boxy.iframeDialog({
                iframeUrl: this.options.iframeUrl,
                title: this.options.title,
                modal: true,
                width: this.options.width,
                height: this.options.height
            });
        };
        this.init = function(args) {
            var _s = this, p;
            this.options.callBackFun = this.options.callBackFun || "newToobar.backFun";
            this.options.title = this.options.title || $(args).attr("title");
            this.options.width = this.options.width || $(args).attr("data-width");
            this.options.height = this.options.height || $(args).attr("data-height");
            if ($(args).attr("id").length == 0) { $(args).attr("id", "id" + parseInt(Math.random() * 10000)); }
            p = { callBackFun: this.options.callBackFun, id: $(args).attr("id"), hide: this.options.hideName, show: this.options.showName };
            this.options.iframeUrl = this.options.iframeUrl || $(args).attr("href");
            if (this.options.iframeUrl.indexOf("?") > 0) {
                this.options.iframeUrl += "&"
            } else {
                this.options.iframeUrl += "?"
            }
            this.options.iframeUrl += $.param(p) + (this.options.para ? "&" + $.param(this.options.para) : "");
            $(args).unbind("click");
            $(args).click(function() { if (_s.options.callFastFun) { window[_s.options.callFastFun](this); } _s.click(this); return false; });
        }
    },
    backFun: function(args) {
        var hide, show;
        hide = $("#" + args.id).parent().find("input[type='hidden']");
        show = $("#" + args.id).parent().find("input[type='text']");
        if (hide.length > 0) { hide.val($.trim(args.value)); }
        if (show.length > 0) { show.val($.trim(args.text)); }
    }
}

/*
处理国家，省份，城市，县区

pcToobar.init({
gID: "# + 国家下拉框ID", 
pID: "# + 省份下拉框ID",
cID: "# + 城市下拉框ID",
xID: "# + 县区下拉框ID",
gSelect: "1", //国家ID，设置1 为选中状态
pSelect:"1",//省份ID，设置1 为选中状态
cSelect:"1",//城市ID，设置1 为选中状态
xSelect:"1", //县区ID，设置1 为选中状态
comID:"必录" 公司ID
})
*/
/*
var pcToobar = {
init: function(options) {
$.extend(this._options, options);
var _self = this;
var obj_g = _self._options.gID.length > 0 && $(_self._options.gID).length > 0 ? $(_self._options.gID) : null;
var obj_p = _self._options.pID.length > 0 && $(_self._options.pID).length > 0 ? $(_self._options.pID) : null;
var obj_c = _self._options.cID.length > 0 && $(_self._options.cID).length > 0 ? $(_self._options.cID) : null;
var obj_x = _self._options.xID.length > 0 && $(_self._options.xID).length > 0 ? $(_self._options.xID) : null;

if (obj_g) {
obj_g.append(_self.defaultShow);
pcToobar._post("g", obj_g, { "get": "g" }, function() { obj_g.change(); });
obj_g.change(function() {
if (obj_p && obj_g.val()) {
obj_p.append(_self.loadShow);
pcToobar._post("p", obj_p, { "get": "p", "gid": obj_g.val() }, function() { obj_p.change(); });
}
})
}
if (obj_p) {
obj_p.append(_self.defaultShow);
obj_p.change(function() {
if (obj_c && obj_p.val()) {
obj_c.append(_self.loadShow);
pcToobar._post("c", obj_c, { "get": "c", "pid": obj_p.val() }, function() { obj_c.change(); });
}
})
if (obj_g == null) {
pcToobar._post("p", obj_p, { "get": "p", "gid": "1" }, function() { obj_p.change(); });
}
}
if (obj_c) {
obj_c.append(_self.defaultShow);
obj_c.change(function() {
if (obj_x && obj_c.val()) {
obj_x.append(_self.loadShow);
pcToobar._post("x", obj_x, { "get": "x", "cid": obj_c.val() }, null);
}
})
if (obj_p == null) {
pcToobar._post("c", obj_c, { "get": "c", "pid": "1" }, function() { obj_c.change(); });
}
}
if (obj_x) {
obj_x.append(_self.defaultShow);
}
},
_options: {
gID: "",
pID: "",
cID: "",
xID: "",
gSelect: "",
pSelect: "",
cSelect: "",
xSelect: "",
comID: ""
},
loadShow: "<option selected=\"selected\" value=\"\">加载中...</option>",
defaultShow: "<option selected=\"selected\" value=\"\">--请选择--</option>",
_post: function(gt, o, para, fun) {
var _self = this;
$.ajax({
type: "get",
cache: false,
url: "/ashx/GetProvinceAndCity.ashx?companyId=" + tableToolbar.CompanyID + "&" + $.param(para),
dataType: "json",
success: function(ret) {
if (ret && ret.list != null) {
_self._appendToSelect(o, ret, gt);
if (fun) {
fun();
}
}
else {
tableToolbar._showMsg("服务器忙！");
return;
}
},
error: function() {
tableToolbar._showMsg("服务器忙！");
return;
}
});
},
_appendToSelect: function(obj, l, type) {
var _self = this;
var list = l.list;
if (list.length > 0) {
obj.html("");
obj.append(_self.defaultShow);
var content = "";
switch (type) {
case "g":
for (var i = 0; i < list.length; i++) {
if (_self._options.gSelect == list[i].id) {
content += "<option selected=\"selected\" value=\"" + list[i].id + "\">" + list[i].name + "</option>";
} else {
content += "<option value=\"" + list[i].id + "\">" + list[i].name + "</option>";
}
}
break;
case "p":
for (var i = 0; i < list.length; i++) {
if (_self._options.pSelect == list[i].id) {
content += "<option selected=\"selected\" value=\"" + list[i].id + "\">" + list[i].name + "</option>";
} else {
content += "<option value=\"" + list[i].id + "\">" + list[i].name + "</option>";
}
}
break;
case "c":
for (var i = 0; i < list.length; i++) {
if (_self._options.cSelect == list[i].id) {
content += "<option selected=\"selected\" value=\"" + list[i].id + "\">" + list[i].name + "</option>";
} else {
content += "<option value=\"" + list[i].id + "\">" + list[i].name + "</option>";
}
}
break;
case "x":
for (var i = 0; i < list.length; i++) {
if (_self._options.xSelect == list[i].id) {
content += "<option selected=\"selected\" value=\"" + list[i].id + "\">" + list[i].name + "</option>";
} else {
content += "<option value=\"" + list[i].id + "\">" + list[i].name + "</option>";
}
}
break;
}
if (content != "") {
obj.append(content);
}
} else {
obj.html(this.defaultShow);
}
}
}*/


//国家、省份、城市、县区联动菜单
var gscx = {
    _loadHTML: "<option value=\"\">加载中...</option>",
    _defaultHTML: "<option value=\"\">--请选择--</option>",
    //获取对象 objId:jQuery#选择器
    _getObj: function(objId) {
        if (objId.length == 0) return null;
        var _$obj = $(objId);
        if (_$obj.length == 0) return null;
        return _$obj;
    },
    //设置下拉菜单项 _$obj:下拉菜单$object items:数据项集合 sv:要选中的值
    _setSelectOptions: function(_$obj, items, sv) {
        _$obj.html("").html(this._defaultHTML);
        if (items.length == 0) return;

        var _s = [];
        for (var i = 0; i < items.length; i++) {
            if (sv == items[i].id) _s.push("<option selected=\"selected\" value=\"" + items[i].id + "\">" + items[i].name + "</option>");
            else _s.push("<option value=\"" + items[i].id + "\">" + items[i].name + "</option>");
        }

        _$obj.append(_s.join(""));
    },
    //发起请求 t:请求类型 g国家 s省份 c城市 x县区 pv:上一级 fn:回调函数
    _post: function(t, options, pv, fn) {
        var _self = this; var _$obj = null; var _data = {}; var _sv = "";

        switch (t) {
            case "g": _$obj = this._getObj(options.gid); _data = { "get": "g" }; _sv = options.gv; break;
            case "s": _$obj = this._getObj(options.sid); _data = { "get": "p", "gid": pv }; _sv = options.sv; break;
            case "c": _$obj = this._getObj(options.cid); _data = { "get": "c", "pid": pv }; _sv = options.cv; break;
            case "x": _$obj = this._getObj(options.xid); _data = { "get": "x", "cid": pv }; _sv = options.xv; break;
            default: break;
        }
        if (!_$obj) { if (fn) fn(); return; }

        _$obj.html("").html(_self._loadHTML);

        $.ajax({
            type: "get", cache: false, dataType: "json",
            url: "/ashx/GetProvinceAndCity.ashx?companyId=" + options.comid + "&isCy=" + options.t + "&lng=" + options.lng + "&" + $.param(_data),
            success: function(response) {
                if (response && response.list != null) {
                    _self._setSelectOptions(_$obj, response.list, _sv);
                    if (fn) { fn(); }
                }
                else {
                    tableToolbar._showMsg("服务器忙！");
                    return;
                }
            },
            error: function() {
                tableToolbar._showMsg("服务器忙！");
                return;
            }
        });
    },
    //设置县区
    _setX: function(options) {
        var _cv = "1";
        var _$c = this._getObj(options.cid);
        if (_$c) _cv = _$c.val();
        this._post("x", options, _cv, null);
    },
    //设置城市
    _setC: function(options) {
        var _sv = "1";
        var _$s = this._getObj(options.sid);
        if (_$s) _sv = _$s.val();
        var _self = this;
        this._post("c", options, _sv, function() { _self._setX(options); });
    },
    //设置省份
    _setS: function(options) {
        var _gv = "1";
        var _$g = this._getObj(options.gid);
        if (_$g) _gv = _$g.val();
        var _self = this;
        this._post("s", options, _gv, function() { _self._setC(options); });
    },
    //设置国家
    _setG: function(options) {
        var _self = this;
        this._post("g", options, "", function() { _self._setS(options); });
    },
    //options={gid:"#国家下拉菜单",sid:"#省份下拉菜单",cid:"#城市下拉菜单",xid:"#县区下拉菜单",gv:"国家选中的值",sv:"省份选中的值",cv:"城市选中的值",xv:"县区选中的值",comid:"公司编号",t:"0所有城市 1常用城市",lng:"语言"}
    init: function(options) {
        var _options = { gid: "", sid: "", cid: "", xid: "", gv: "", sv: "", cv: "", xv: "", comid: "", t: "0", lng: "0" };
        options = $.extend(_options, options);
        var _$g = this._getObj(options.gid);
        var _$s = this._getObj(options.sid);
        var _$c = this._getObj(options.cid);
        var _$x = this._getObj(options.xid);
        var _self = this;
        if (_$g) { _$g.bind("change", function() { _self._setS(options); }); }
        if (_$s) { _$s.bind("change", function() { _self._setC(options); }); }
        if (_$c) { _$c.bind("change", function() { _self._setX(options); }); }
        if (_$x) { }

        this._setG(options);
    }
};
var pcToobar = {
    ginit: function(options) {
        this.init(options);
    },
    init: function(options) {
        var _options = { gid: options.gID, sid: options.pID, cid: options.cID, xid: options.xID, gv: options.gSelect, sv: options.pSelect, cv: options.cSelect, xv: options.xSelect, comid: options.comID, t: options.isCy, lng: options.lng }
        gscx.init(_options);
    }
};

//toxls 导出列表 toXls.init({"selector":"#elem"});
var toXls = {
    //click
    __toXls: function(options) {
        if (pagingRecordCount == 0) { tableToolbar._showMsg("暂无任何数据供导出。"); return false; }

        var _params = utilsUri.getUrlParams([]);

        _params["toxls"] = "1";
        _params["toxlsrecordcount"] = pagingRecordCount;

        window.location.href = utilsUri.createUri(options["url"], _params);

        return false;
    },
    //int options:{"selector":"导出按钮选择器","url":"导出请求页面URL，默认当前URL"}
    init: function(options) {
        options = options || {};
        options = $.extend({ "selector": "", "url": window.location.pathname }, options);

        var _selector = options["selector"];
        if (_selector === undefined || _selector.length == 0) return;

        $(_selector).bind("click", function() { return toXls.__toXls(options); });
    }
};

//toxls 导出列表 url:导出请求页面URL，默认当前URL
function toXls1(url) {
    url = url || window.location.pathname;
    return toXls.__toXls({ "url": url });
}

function PrintPage(Selector) {
    if (window.print != null) {
        window.print();
    } else {
        tableToolbar._showMsg("没有安装打印机");
    }
}

/*列表中查看计调项的泡泡处理 计调项费用明细泡泡*/
var BtFun = {
    InitBindBt: function(tdContainer) {
        $("#liststyle").find("td[data-class='" + tdContainer + "']").mouseover(function() {
            var _$obj = $(this);
            _$obj.unbind("mouseover");
            var _tourid = _$obj.attr("data-tourId");
            if (_$obj.find("b[class!='fontgray']").length == 0) return;

            $.ajax({
                type: "get", url: '/Ashx/Handler.ashx?doType=GetJiDiaoAnPaiFuDongNeiRong&tourId=' + _tourid, dataType: "json",
                success: function(response) {
                    if (response == null || response.length == 0) return;

                    for (var i = 0; i < response.length; i++) {
                        var _item = response[i];
                        var _html = [];
                        _html.push(_item.GysName);
                        if (_item.TI == 7) {
                            _html.push("&nbsp;电话：");
                            _html.push(_item.Telephone);
                        }
                        _html.push("<br/>");
                        _$obj.find("div[data-type='" + _item.TI + "']").append(_html.join(''));
                    }

                    _$obj.find("b[class!='fontgray']").each(function() {
                        var _ts = $(this);
                        if (_ts.next().length > 0 && _ts.next().get(0).tagName == "DIV" && _ts.next().html() != "") {
                            _ts.bt({
                                contentSelector: function() { return $(this).next().html(); },
                                positions: ['left', 'right', 'bottom', 'top'],
                                fill: '#FFF2B5',
                                strokeStyle: '#D59228',
                                noShadowOpts: { strokeStyle: "#D59228" },
                                spikeLength: 10,
                                spikeGirth: 15,
                                width: 200,
                                overlap: 0,
                                centerPointY: 1,
                                cornerRadius: 4,
                                shadow: true,
                                shadowColor: 'rgba(0,0,0,.5)',
                                cssStyles: { color: '#00387E', 'line-height': '180%' }
                            });
                        }
                    });
                }
            });
        });
    }
}

//用户控件相关
var wuc = {
    //财务筛选用户控件 params.uniqueID：window.wucClientUniqueID obj。
    caiWuShaiXuan: function(uniqueID) {
        //获取操作符
        this.getOperator = function() {
            return $("#" + uniqueID["ClientUniqueIDOperator"]).val();
        };
        //获取操作数
        this.getOperatorNumber = function() {
            return $("#" + uniqueID["ClientUniqueIDOperatorNumber"]).val();
        }
        //设置操作符
        this.setOperator = function(_v) {
            $("#" + uniqueID["ClientUniqueIDOperator"]).val(_v);
        }
        //设置操作数
        this.setOperatorNumber = function(_v) {
            $("#" + uniqueID["ClientUniqueIDOperatorNumber"]).val(_v);
        }

        return this;
    }
};
//英文转中文
var EnglishToChanges = {
    _englishtochangedata: {
        Add: "-新增-",
        Update: "-修改-",
        Del: "-删除-",
        Copy: "-复制-",
        Show: "-查看-",
        SetMoney: "-收款-",
        ReturnMoney: "-退款-",
        Register: "-登记-",
        Pay: "-支付-",
        ExamineV: "-审核-",
        ExamineA: "-审批-",
        WriteOff: "-销帐-",
        Apply: "-报销-",
        OpenInvoice: "-开票-",
        Stop: "-停用-",
        Start: "-启用-",
        parsererror: tableToolbar.errorMsg,
        timeout: tableToolbar.errorMsg,
        error: tableToolbar.errorMsg,
        notmodified: tableToolbar.errorMsg
    },
    Ping: function(type) {
        return this._englishtochangedata[type];
    }
}

var keSimple = ['source', '|', 'cut', 'copy', 'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'clearhtml', 'selectall', '|', 'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', '|', 'table', 'hr', 'emoticons', 'link', 'unlink'];

var keSimple_HaveImage = ['source', '|', 'cut', 'copy', 'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'clearhtml', 'selectall', '|', 'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', '|', 'table', 'hr', 'emoticons', 'link', 'unlink', '|', 'image'];
var keMore = ['source', '|', 'cut', 'copy', 'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'clearhtml', 'quickformat', 'selectall', '|', 'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', '|', 'table', 'hr', 'emoticons', 'link', 'unlink'];

var keMore_HaveImage = ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
        'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
        'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
        'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
        'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
        'anchor', 'link', 'unlink', '|', 'about'];

var KEditer = {
    //创建编辑器
    init: function(id, options) {
        var e = { id: id, edit: null }, op = options || { resizeMode: 0, items: keSimple, height: "150px", width: "800px" };
        e.edit = KindEditor.create('#' + id, op);
        KEditer.list.push(e);
    },
    //缓存编辑器对象
    list: [],
    //同步编辑器的值
    sync: function(id) {
        var i = 0, _self = this, e;
        if (_self.list.length > 0) {
            for (; i < _self.list.length; i++) {
                e = _self.list[i];
                if (id) {
                    if (e.id == id) {
                        e.edit.sync();
                        break;
                    }
                } else {
                    if (document.getElementById(e.id) != null) {
                        //同步数据
                        e.edit.sync();
                    } else {
                        //移除
                        _self.list.splice(i, 1);
                    }
                }
            }
        }
    },
    //移除指定编辑器
    remove: function(id) {
        var i = 0, _self = this, e;
        if (_self.list.length > 0) {
            for (; i < _self.list.length; i++) {
                e = _self.list[i];
                if (id == e.id) {
                    e.edit.remove();
                    _self.list.splice(i, 1);
                    break;
                }
            }
        }
    },
    html: function(id, val) {
        var i = 0, _self = this, e;
        if (_self.list.length > 0) {
            for (; i < _self.list.length; i++) {
                e = _self.list[i];
                if (id == e.id) {
                    e.edit.html(val);
                    break;
                }
            }
        }
    },
    isInit: function(id) {
        var _isInit = false;
        for (var i = 0; i < this.list.length; i++) {
            if (this.list[i].id == id) { _isInit = true; break; }
        }
        return _isInit;
    }
}
