/// <reference path="_references.js" />

var viewModel = (function () {
    "use strict";
    var viewModel = {};
    viewModel.messages = ko.observableArray();
    return viewModel;
})();
$(document).ready(function () {
    $.connection.hub.start();

    ko.applyBindings(viewModel);
});