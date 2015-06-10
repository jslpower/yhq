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
        var settings = {  speed: 40, step: 10 };
        if (options) $.extend(settings, options);
        var container = $(this);
        var table = container.children();
        var isActive = false;
        $("body").append('<div style="width:50px;position:absolute;display:none;font-size:0px; " id="scrollBar">></div>');
        var tmp;
        var bar = $("#scrollBar");
        bar.css("height", container.height());
		function changeheight(){
				if(table.width()>container.width()){
			container.height(table.height()+16);
		}
			}
			changeheight();
			$(window).resize(changeheight);
        container.mouseover(function() {
            $(this).bind("mousemove", function(evt) {
                //console.log(evt.clientX);
                //console.log(container.offset().left);
                var pos = evt.clientX - container.offset().left;
                if (pos > container.width() - 50 && !isActive && container.scrollLeft() < table.get(0).clientWidth - container.width()) {
                    bar.html("<div class='gdjiantou'><a herf='#'></a></div>");
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
                    bar.html(" <div class='gdjiantou-l'><a herf='#'></a></div>");
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
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//自动添加行，使用方法:jquery容器.autoAdd({参数}); by 田想兵 2011.9.7
//options{tempRowClass:"模版行样式", addButtonClass:"添加按钮样式",delButtonClass:"删除按钮样式"}
//调用示例$(".content").autoAdd();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
*/
(function($) {
    $.fn.autoAdd = function(options) {
        var settings = { changeInput: $("#input"), tempRowClass: "tempRow", min: 1, max: 90, addButtonClass: "addbtn", delButtonClass: "delbtn", addCallBack: null, delCallBack: null, indexClass: "index", insertClass: "insertbtn", moveUpClass: "moveupbtn", moveDownClass: "movedownbtn" };
        if (options) $.extend(settings, options);
        var content = this;
        var count = content.find("." + settings.tempRowClass).length;
        settings.changeInput.change(function() {
            if (/^\d+$/.test($(this).val())) {
                if ($(this).val() > settings.max || $(this).val() < settings.min) {
                    alert("请输入大于等于 " + settings.min + " 并且小于等于 " + settings.max + " 的数!");
                    if ($(this).val() > settings.max)
                        $(this).val(settings.max);
                    if ($(this).val() < settings.min)
                        $(this).val(settings.min);
                    $(this).change();
                } else {
                    addRow($(this).val());
                }
            } else {
                alert("请输入有效的整数！");
                $(this).focus();
            }
        });
        function addRow(num, isInsert, target) {
            //console.log(temp);
            //var strTemp = "";
            for (var i = 0; i < num - count; i++) {
                var temp = content.find("." + settings.tempRowClass).first().clone(true);
                temp.find("input").val("");
                temp.find("select").val("-1");
                temp.find("textarea").val("");
                temp.find(":checkbox").attr("checked", false);
                if (temp.find(".richText").length > 0) {
                    temp.find(".ke-container").remove();
                    temp.find(".richText").each(function() {
                        $(this).attr("id", "txt_" + Math.round(new Date().getTime()))
                        $(this).show();
                    });
                }
                //strTemp += "<tr>" + temp.html() + "</tr>";
                if (isInsert) {
                    temp.insertBefore(target.closest("." + settings.tempRowClass));
                } else {
                    content.append(temp);
                }
            }
            if (num < count) {
                for (var j = count - 1; j >= num; j--) {
                    delRow(content.children().eq(j));
                }
            } else {
                //content.append($(strTemp));
                if (settings.addCallBack)
                    settings.addCallBack($(strTemp));
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
                alert("最多只能添加 " + settings.max + " 行记录!");
            } else {
                addRow(count + 1);
            }
            return false;
        });
        content.find("." + settings.insertClass).bind("click", function() {
            if (count >= settings.max) {
                alert("最多只能添加 " + settings.max + " 行记录!");
            } else {
                addRow(count + 1, true, $(this));
            }
            return false;
        });
        content.find("." + settings.moveUpClass).bind("click", function() {
            $(this).closest("." + settings.tempRowClass).insertBefore($(this).closest("." + settings.tempRowClass).prev("." + settings.tempRowClass));
            showhideBtn();
            sumIndex();
            return false;
        });
        content.find("." + settings.moveDownClass).bind("click", function() {
            $(this).closest("." + settings.tempRowClass).insertAfter($(this).closest("." + settings.tempRowClass).next("." + settings.tempRowClass));
            showhideBtn();
            sumIndex();
            return false;
        });
        content.find("." + settings.delButtonClass).bind("click", function() {
            //console.log(count);
            if (count > settings.min) {
                count--;
                delRow($(this).closest("." + settings.tempRowClass));
            } else {
                alert("需至少保留 " + settings.min + " 行记录!");
            }
            return false;
        });
        function delRow(row) {
            row.remove();
            count = content.find("." + settings.tempRowClass).length;
            settings.changeInput.val(count);
            if (settings.delCallBack)
                settings.delCallBack(content.children().eq(j));
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
selectToobar.init({})单个选择
selectToobar.initMore多个选择
demo:
var a = new selectToobar();
a.init({ clickObj: 选择按钮对象, hideObj: 隐藏域对象, showObj: 显示文本框对象, iframeUrl: "ReturnPage.aspx", title: "新的页面", width: "300px", height: "300px" });
var b = new newToobar();
b.initMore({ className: "选择按钮样式名", hideName: "隐藏域name", showName: "显示域name", iframeUrl: "ReturnPage.aspx", title: "新的页面", width: "300px", height: "300px" })
****/
var selectToobar = function() {
    this.options = {
        clickObj: null,
        hideObj: null,
        showObj: null,
        iframeUrl: "",
        title: "",
        modal: true,
        width: "",
        height: "",
        className: "",
        hideName: "",
        showName: ""
    }
}


selectToobar.prototype.click = function() {
    Boxy.iframeDialog({
        iframeUrl: this.options.iframeUrl,
        title: this.options.title,
        modal: this.options.modal,
        width: this.options.width,
        height: this.options.height
    });
}

selectToobar.prototype.init = function(_options) {
    var self = this;
    $.extend(self.options, _options);

    if (this.options.hideObj != null) {
        if ($(this.options.hideObj).attr("id") == undefined || $(this.options.hideObj).attr("id") == "") {
            $(this.options.hideObj).attr("id", this._gethideID);
        }
    }
    if (this.options.showObj != null) {
        if ($(this.options.showObj).attr("id") == undefined || $(this.options.showObj).attr("id") == "") {
            $(this.options.showObj).attr("id", this._getshowID);
        }
    }
    if (this.options.iframeUrl.indexOf("?") <= 0) {
        this.options.iframeUrl += "?hideID=" + $(this.options.hideObj).attr("id") + "&showID=" + $(this.options.showObj).attr("id") + "&return=" + $(this.options.hideObj).val();
    }

    if (self.options.clickObj != null) {
        self.options.clickObj.click(function() {

            self.click();
        })
    }

}

selectToobar.prototype._gethideID = function() {
    return "hide_" + Math.round(Math.random() * 10000);
}
selectToobar.prototype._getshowID = function() {
    return "show_" + Math.round(Math.random() * 10000);
}

selectToobar.prototype._default = {
    clickObj: null,
    hideObj: null,
    showObj: null,
    iframeUrl: "",
    title: "",
    modal: true,
    width: "500px",
    height: "500px",
    className: "",
    hideName: "",
    showName: ""
}

var newToobar = function() {
    this.options = {
        iframeUrl: "",
        title: "",
        modal: true,
        width: "500px",
        height: "500px",
        className: "",
        hideName: "",
        showName: ""
    }
}

newToobar.prototype.initMore = function(options) {
    var _self = this;
    $.extend(_self.options, options);
    if (_self.options.className != "") {
        $("." + _self.options.className).each(function() {
            var _newSelf = new selectToobar();
            _newSelf.init({ clickObj: $(this), hideObj: $(this).parent().find("input[name='" + _self.options.hideName + "']"), showObj: $(this).parent().find("input[name='" + _self.options.showName + "']"), iframeUrl: _self.options.iframeUrl, title: _self.options.title, width: _self.options.width, height: _self.options.height });
        })
    }
}

