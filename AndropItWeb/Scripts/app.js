/// <reference path="_references.js" />

var viewModel = (function () {
    "use strict";
    var viewModel = {};
    viewModel.messages = ko.observableArray([
        { content: "http://google.ca", type: "url" },
        { content: "4178887777", type: "phone" },
        {content:"This is some text", type:"text"}
    ]);
    return viewModel;
})();

ko.applyBindings(viewModel);