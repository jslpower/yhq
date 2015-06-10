/*汪奇志 2012-02-21 js utils uri*/
var utilsUri = {
    /*创建请求URL,url:请求URL,params:查询参数{}*/
    createUri: function(url, params) {
        if (url == null || url.length < 1) url = window.location.pathname;
        var isHaveParam = false;
        var isHaveQuestionMark = false;
        var questionMark = "?";
        var questionMarkIndex = url.indexOf(questionMark);
        var urlLength = url.length;

        if (questionMarkIndex == urlLength - 1) {
            isHaveQuestionMark = true;
        } else if (questionMarkIndex != -1) {
            isHaveParam = true;
        }

        if (isHaveParam == true) {
            for (var key in params) {
                url = url + "&" + key + "=" + encodeURIComponent(params[key]);
            }
        } else {
            if (isHaveQuestionMark == false) {
                url += questionMark;
            }
            for (var key in params) {
                url = url + key + "=" + encodeURIComponent(params[key]) + "&";
            }
            url = url.substr(0, url.length - 1);
        }

        return url;
    },
    /*获取查询参数，removeParams：要移除的键[]*/
    getUrlParams: function(removeParams) {
        removeParams = removeParams || [];
        var argsArr = {};
        var query = window.location.search;
        query = query.substring(1);
        var pairs = query.split("&");

        for (var i = 0; i < pairs.length; i++) {
            var sign = pairs[i].indexOf("=");
            if (sign == -1) {
                continue;
            }

            var aKey = pairs[i].substring(0, sign);
            var aValue = decodeURIComponent(pairs[i].substring(sign + 1));

            /*移除不需要要的键*/
            var isRemove = false;
            for (var j = 0; j < removeParams.length; j++) {
                if (aKey.toLowerCase() == removeParams[j].toLowerCase()) {
                    isRemove = true;
                    break;
                }
            }

            if (isRemove) {
                continue;
            }

            argsArr[aKey] = aValue;
        }

        return argsArr;
    },
    /*初始化查询 params:查询参数{}*/
    initSearch: function(params) {
        params = params || this.getUrlParams();
        for (var key in params) {
            $("#" + key).val(params[key]);
        }
    }
};
