

var uri = {
    href: window.location.href,
    hash: window.location.hash
};


if (uri.href == "http://localhost:48296/" || uri.href == "http://localhost:48296/#" || uri.href == "http://localhost:48296/Default.aspx" || uri.href == "http://localhost:48296/Default.aspx#") {

    $("a[href='About.aspx']")[0].click(); 
    //$("a[href='About.aspx']").click();
    //$("a[href='About.aspx']").trigger("click");
    //$("a[href='About.aspx']")[0].trigger("click");
    // window.location.href = "About.aspx";       
}

if (uri.href == "http://localhost:48296/About.aspx" || uri.href == "http://localhost:48296/About.aspx#") {
    $("input[id='MainContent_TextBox1']").val("Hallo");
    $("input[id='MainContent_TextBox2']").val("Welt");
    $("#MainContent_ButtonSenden").click();
    
    //Ende
    amplify.store("NPlayJS", null);
}
