var common = {
  scrollTo: function (selector) {
    var element = $(selector);
    element.show(function () {
      $("html, body").animate({
        scrollTop: element.offset().top - 60
      }, 1000);
    });
  }
};