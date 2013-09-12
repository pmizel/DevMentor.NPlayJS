

var uri = {
    href: window.location.href,
    hash: window.location.hash
};


if (true) { //egal wo du bist.

    //window.location.href = "/Account/Login.aspx";
    $("a[id='HeadLoginView_HeadLoginStatus']")[0].click(); 
    //$("a[href='About.aspx']").click();
    //$("a[href='About.aspx']").trigger("click");
    //$("a[href='About.aspx']")[0].trigger("click");
    // window.location.href = "About.aspx";       
}

if (uri.href == "http://localhost:48296/Account/Login.aspx") {
    $("input[id='MainContent_LoginUser_UserName']").val("Hallo");
    $("input[id='MainContent_LoginUser_Password']").val("Welt");
    $("#MainContent_LoginUser_LoginButton").click();
    
    //Ende
    amplify.store("NPlayJS", null);
}
