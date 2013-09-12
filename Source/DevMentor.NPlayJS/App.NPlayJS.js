$(function () {


    $("#nplayjs").append("{0}");

    $("#nplayjs a.play").click(function () {
        alert("Play");
        //$("head").append("<script href='" + this.text + "' type='text/javascript'></script>");
        var scriptNPlayJs = document.createElement("script");
        scriptNPlayJs.type = "text/javascript";
        scriptNPlayJs.src = this.text;
        document.getElementsByTagName('head')[0].appendChild(scriptNPlayJs);
        
        amplify.store("NPlayJS", {
            state: "Play",
            script: this.innerText
        });
    });

    var status=amplify.store("NPlayJS");
    if(status!=null) //play?
    {
        var scriptNPlayJs = document.createElement("script");
        scriptNPlayJs.type = "text/javascript";
        scriptNPlayJs.src = status.script;
        document.getElementsByTagName('head')[0].appendChild(scriptNPlayJs);
    }

});


