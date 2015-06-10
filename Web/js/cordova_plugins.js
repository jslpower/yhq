cordova.define('cordova/plugin_list', function(require, exports, module) {
    module.exports = [
    {
        "file": "plugins/org.apache.cordova.device/www/device.js",
        "id": "org.apache.cordova.device.device",
        "clobbers": [
            "device"
        ]
    },
    {
        "file": "plugins/org.apache.cordova.network-information/www/network.js",
        "id": "org.apache.cordova.network-information.network",
        "clobbers": [
            "navigator.connection",
            "navigator.network.connection"
        ]
    },
    {
        "file": "plugins/org.apache.cordova.network-information/www/Connection.js",
        "id": "org.apache.cordova.network-information.Connection",
        "clobbers": [
            "Connection"
        ]
    },
    {
        "file": "plugins/org.apache.cordova.dialogs/www/notification.js",
        "id": "org.apache.cordova.dialogs.notification",
        "merges": [
            "navigator.notification"
        ]
    },
    {
        "file": "plugins/org.apache.cordova.dialogs/www/android/notification.js",
        "id": "org.apache.cordova.dialogs.notification_android",
        "merges": [
            "navigator.notification"
        ]
    },
    {
        "file": "plugins/com.enow.plugins/barcodescanner.js",
        "id": "com.enow.plugins.barcodescanner",
        "merges": [
            "enow.erweima"
        ]
    },
    {
        "file": "plugins/com.enow.plugins/wifi.js",
        "id": "com.enow.plugins.wifi",
        "merges": [
            "enow.wifi"
        ]
    }
];

    module.exports.metadata =
    // TOP OF METADATA
{
"org.apache.cordova.device": "0.2.5",
"org.apache.cordova.network-information": "0.2.5",
"org.apache.cordova.dialogs": "0.2.4",
"com.enow.plugins.barcodescanner": "0.0.1",
"com.enow.plugins.wifi": "0.0.1"
}
    // BOTTOM OF METADATA
});