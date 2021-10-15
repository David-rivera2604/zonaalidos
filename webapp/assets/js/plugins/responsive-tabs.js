function tabToAccordion(){
    var navTab = $(".nav-tabs"),
        tabContent = $(".tab-content");
        // hiding the navtabs
    navTab.hide();
    // appending each link to respective tab-pane
        navTab.find("li").each(function(){
            var destination = $($(this).find(".nav-link").attr("href"));
            var anchor = $(this).find(".nav-link");
            // removing unused attributes and adding tabContent-toggler class
            anchor.removeAttr("data-toggle role aria-controls aria-selected").addClass("tabContent-toggler").insertBefore(destination);
        });
    var tabToggler = $('.tabContent-toggler'),
    tabPane = tabContent.find(".tab-pane"),
    // get all classes in tab pane for further usage and replace tab-pane with empty data
    nonActiveTabPane = tabContent.find(".tab-pane:not(.active)").attr("class");
    tabPaneClass = tabPane.attr('class');
    tabPaneClass = tabPaneClass.replace(nonActiveTabPane,"");
    tabToggler.click(function(e){
        // get the destination of clicked element
        var destination = $($(this).attr("href"));
        // if not this element then remove active class
        $(this).parent().find(tabToggler).not($(this)).removeClass("active");
        //if not clicked destination then remove all other class except tab-pane
        $(this).parent().find('.tab-pane').removeClass(tabPaneClass);
        // now toggle active class
        $(this).toggleClass("active");
        // also toggle all other class in tab-pane
        destination.toggleClass(tabPaneClass);
        // if this element dont have active class then remove all other class from tab-pane
        if(!$(this).hasClass("active")){
            destination.removeClass(tabPaneClass);
        }
        // first element of nested tab-pane should be active
        if(destination.has(tabToggler)){
            var tabTogglerFirstChild = destination.find(".tabContent-toggler:first-child"),
            tabTogglerFirstDestination = $(tabTogglerFirstChild.attr("href"));
            tabTogglerFirstChild.addClass("active");
            tabTogglerFirstDestination.addClass(tabPaneClass);
        }
        // preventing default behaviour of element
        e.preventDefault();
    });
}
// check if device is mobile and if so only run the function
if(/Mobi/.test(navigator.userAgent)){
    tabToAccordion();
}