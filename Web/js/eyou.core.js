/**
* @fileOverview:eyou.core.js
* @author:汪奇志 2013-12-17
* @requires:cordova.js,cordova.plugin.barcodescanner.js
* @version:0.0.0.1
*/ 

(function() {
    if (!window.eYou) { window.eYou = {}; }

    //首页URL
    var __surl = "SaoMiao.aspx";

    /**
    * @description:二维码扫描
    * @options:{callback:function(winParam){},error:function(error){}}
    * @options.callback:成功回调函数 winParam:{text:"字符类型：编码内容",format:"字符类型：编码格式",cancelled:"布尔类型：是否取消扫描"}
    * @option.error:失败回调函数
    */
    window.eYou.saoMiao = function(options) {
        if (typeof (options) === 'undefined') options = {};
        if (typeof (options.callback) !== 'function') options.callback = function(winParam) { };
        if (typeof (options.error) !== 'function') options.err = function(error) { };

        enow.erweima.scan('', options.callback, options.error);
    };

    /**
    *@description:获取网络连接类型
    *@return:
    */
    window.eYou.getConnectionType = function() {
        var _networkState = navigator.connection.type;

        var _states = {};
        _states[Connection.UNKNOWN] = 'UNKNOWN';
        _states[Connection.ETHERNET] = 'ETHERNET';
        _states[Connection.WIFI] = 'WIFI';
        _states[Connection.CELL_2G] = 'CELL_2G';
        _states[Connection.CELL_3G] = 'CELL_3G';
        _states[Connection.CELL_4G] = 'CELL_4G';
        _states[Connection.CELL] = 'CELL';
        _states[Connection.NONE] = 'NONE';

        return _states[_networkState];
    };

    /**
    *@description:alert警告消息框 
    *@options:{message:'消息内容',title:'消息标题',callback:function(){var s='返回事件';},btnName:'按钮名称'}
    */
    window.eYou.alert = function(options) {
        if (typeof (options) === 'undefined') return;
        if (typeof (options.btnName) === 'undefined') options.btnName = '确定';
        if (typeof (options.callback) !== 'function') options.callback = function() { };
        if (typeof (options.title) === 'undefined') options.title = '消息';
        if (typeof (options.message) === 'undefined') options.message = '消息内容';

        navigator.notification.alert(options.message, options.callback, options.title, options.btnName);
    };

    /**
    *@description:confirm确认消息框 
    *@options:{message:'消息内容',title:'消息标题',callback:function(button){var s='返回事件';},btnOk:'OK按钮名称',btnCancel:'Cancel按钮名称'},callback.button:按下按钮索引
    */
    window.eYou.confirm = function(options) {
        if (typeof (options) === 'undefined') return;
        if (typeof (options.btnOk) === 'undefined') options.btnName = '确定';
        if (typeof (options.btnCancel) === 'undefined') options.btnName = '取消';
        if (typeof (options.callback) !== 'function') options.callback = function(button) { };
        if (typeof (options.title) === 'undefined') options.title = '消息';
        if (typeof (options.message) === 'undefined') options.message = '消息内容?';

        navigator.notification.confirm(options.message, options.callback, options.title, options.btnOk + ',' + options.btnCancel);
    };

    /**
    *@description:有网络连接时触发事件
    */
    window.eYou._onOnline = function() {
        //window.eYou.alert({ message: '网络已连接' });
    };

    /**
    *@description:无网络连接时触发事件
    */
    window.eYou._onOffline = function() {
        //window.eYou.alert({ message: '暂时无网络连接，请连接后重试' });
    };

    /**
    *@description:设备就绪(PhoneGap被完全加载)时触发事件
    */
    window.eYou._onDeviceReady = function(options) {
        document.addEventListener("online", options.onOnline, false);
        document.addEventListener("offline", options.onOffline, false);
    };

    /**
    *@description:刷新 
    *@url:url
    */
    window.eYou.reload = function(url) {
        if (typeof (url) === 'undefined') url = __surl;

        if (window.eYou.getConnectionType() == 'NONE') {
            window.eYou.alert({ message: '暂时无网络连接，请连接后重试' });
            return;
        }

        window.location.href = url;
    };

    /**
    *@description:wifi管理
    *@options：{state:true||false,callback:function(winParam){}}
    */
    window.eYou.wifi = function(options) {
        if (typeof options === 'undefined') return;
        if (typeof options.state === 'undefined') return;
        if (typeof options.callback !== "function") options.callback = function(winParam) { };

        if (options.state) enow.wifi.open('', options.callback, null);
        else enow.wifi.close('', options.callback, null);
    };

    /**
    *@description:eYou初始化
    *@options:options.onOnline:有网络连接时触发事件,option.onOffline:无网络连接时触发事件,option.fn:其它需要执行的事件
    */
    window.eYou.ready = function(options) {
        var _options = { onOnline: window.eYou._onOnline, onOffline: window.eYou._onOffline, fn: function() { } };

        if (typeof (options) === 'undefined') {
            options = _options;
        } else {
            if (typeof (options.onOnline) !== 'function') options.onOnline = window.eYou._onOnline;
            if (typeof (options.onOffline) !== 'function') options.onOffline = window.eYou._onOffline;
            if (typeof (options.fn) !== 'function') options.fn = null;
        }

        document.addEventListener("deviceready", function() { window.eYou._onDeviceReady(options); }, false);

        if (options.fn != null) options.fn();
    };
})();
