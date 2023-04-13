//var prevScrollpos = window.pageYOffset;
//window.onscroll = function () {
//    var currentScrollPos = window.pageYOffset;
//    if (prevScrollpos > currentScrollPos) {
//        document.getElementById("navbar").style.top = "100px";
//        //$("#navbar").removeAttr('style');
//        //$("#navbar").addClass("bg-dark");
//    } else {
//        document.getElementById("navbar").style.top = "100px";
//    }
//    prevScrollpos = currentScrollPos
//    //if (prevScrollpos == 0) {
//    //    $("#navbar").removeClass("bg-dark");
//    //}
//}

//fitter section slide in out
const openNav = () => {
    document.getElementById('mySidenav').style.width = "350px";
    $("#mySidenav").removeClass("d-none d-lg-block col-sm-3 sidenav-close").addClass("d-block sidenav");
}
const closeNav = () => {
    document.getElementById('mySidenav').style.width = "0px";

    $("#mySidenav").removeClass("d-block sidenav").addClass("d-none d-lg-block col-sm-3");
    $("#mySidenav").removeAttr('style');
}