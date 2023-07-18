function wxConfig(data) {
    var sign = JSON.parse(data);
    wx.config({
        debug: false,
        appId: sign.appID,
        timestamp: sign.timestamp,
        nonceStr: sign.noncestr,
        signature: sign.signature,
        jsApiList: [
            "onMenuShareTimeline",
            "onMenuShareAppMessage",
            "onMenuShareQQ",
            "onMenuShareWeibo",
            "onMenuShareQZone"
        ]
    });
}

function wxReady(shareData, url) {
    wx.ready(function () {
        wx.error(function (res) {
            alert("wx错误！");
        });
        //分享到朋友圈
        wx.onMenuShareTimeline({
            title: shareData.title,
            desc: shareData.desc,
            link: shareData.link,
            imgUrl: shareData.imgUrl,
            success: function () {
                alert("分享成功！");
                $(".share-container").hide();
                if (url) {
                    $.post(url, shareData);
                }
            },
            cancel: function () {
                alert("取消分享！");
                $(".share-container").hide();
            }
        });
        //分享给朋友
        wx.onMenuShareAppMessage({
            title: shareData.title,
            desc: shareData.desc,
            link: shareData.link,
            imgUrl: shareData.imgUrl,
            success: function () {
                alert("分享成功！");
                $(".share-container").hide();
                if (url) {
                    $.post(url, shareData);
                }
            },
            cancel: function () {
                alert("取消分享！");
                $(".share-container").hide();
            }
        });
        //分享到QQ
        wx.onMenuShareQQ({
            title: shareData.title,
            desc: shareData.desc,
            link: shareData.link,
            imgUrl: shareData.imgUrl,
            success: function () {
                alert("分享成功！");
                $(".share-container").hide();
                if (url) {
                    $.post(url, shareData);
                }
            },
            cancel: function () {
                alert("取消分享！");
                $(".share-container").hide();
            }
        });
        //分享到腾讯微博
        wx.onMenuShareWeibo({
            title: shareData.title,
            desc: shareData.desc,
            link: shareData.link,
            imgUrl: shareData.imgUrl,
            success: function () {
                alert("分享成功！");
                $(".share-container").hide();
                if (url) {
                    $.post(url, shareData);
                }
            },
            cancel: function () {
                alert("取消分享！");
                $(".share-container").hide();
            }
        });
        //分享到QQ空间
        wx.onMenuShareQZone({
            title: shareData.title,
            desc: shareData.desc,
            link: shareData.link,
            imgUrl: shareData.imgUrl,
            success: function () {
                alert("分享成功！");
                $(".share-container").hide();
                if (url) {
                    $.post(url, shareData);
                }
            },
            cancel: function () {
                alert("取消分享！");
                $(".share-container").hide();
            }
        });
    });
}