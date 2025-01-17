﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(function () {
        $('#datetimepicker1').datetimepicker();
 });


    var nav = new DayPilot.Navigator("nav");
    nav.showMonths = 3;
    nav.skipMonths = 3;
    nav.selectMode = "week";
    nav.onTimeRangeSelected = function (args) {
        dp.startDate = args.day;
        dp.update();
        dp.events.load("/api/events");
    };
    nav.init();
    

    var dp = new DayPilot.Calendar("dp");
    dp.viewType = "Week";
    dp.onTimeRangeSelected = function (args) {
        DayPilot.Modal.prompt("Create a new event:", "Event").then(function (modal) {
            var dp = args.control;
            dp.clearSelection();
            if (!modal.result) {
                return;
            }
            var params = {
                start: args.start.toString(),
                end: args.end.toString(),
                text: modal.result,
                resource: args.resource
            };
            $.ajax({
                type: 'POST',
                url: '/api/events',
                data: JSON.stringify(params),
                success: function (data) {
                    dp.events.add(new DayPilot.Event(data));
                    dp.message("Event created");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        });
    };
    dp.onEventMove = function (args) {
        var params = {
            id: args.e.id(),
            start: args.newStart.toString(),
            end: args.newEnd.toString()
        };
        $.ajax({
            type: 'PUT',
            url: '/api/events/' + args.e.id() + "/move",
            data: JSON.stringify(params),
            success: function (data) {
                dp.message("Event moved");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    };
    dp.onEventResize = function (args) {
        var params = {
            id: args.e.id(),
            start: args.newStart.toString(),
            end: args.newEnd.toString()
        };
        $.ajax({
            type: 'PUT',
            url: '/api/events/' + args.e.id() + "/move",
            data: JSON.stringify(params),
            success: function (data) {
                dp.message("Event resized");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    };
    dp.onBeforeEventRender = function (args) {
        args.data.barColor = args.data.color;
        args.data.areas = [
            { top: 2, right: 2, icon: "icon-triangle-down", visibility: "Hover", action: "ContextMenu", style: "font-size: 12px; background-color: #f9f9f9; border: 1px solid #ccc; padding: 2px 2px 0px 2px; cursor:pointer;" }
        ];
    };
    dp.contextMenu = new DayPilot.Menu({
        items: [
            {
                text: "Delete",
                onClick: function (args) {
                    var e = args.source;
                    $.ajax({
                        type: 'DELETE',
                        url: '/api/events/' + e.id(),
                        success: function (data) {
                            dp.events.remove(e);
                            dp.message("Event deleted");                            
                        },
                        contentType: "application/json",
                        dataType: 'json'
                    });
                }
            },
            {
                text: "-"
            },
            {
                text: "Blue",
                icon: "icon icon-blue",
                color: "#1066a8",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },
            {
                text: "Green",
                icon: "icon icon-green",
                color: "#6aa84f",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },
            {
                text: "Yellow",
                icon: "icon icon-yellow",
                color: "#f1c232",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },
            {
                text: "Red",
                icon: "icon icon-red",
                color: "#cc0000",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },

        ]
    });
    dp.init();

    dp.events.load("/api/events");


    function updateColor(e, color) {
        var params = {
            color: color
        };
        $.ajax({
            type: 'PUT',
            url: '/api/events/' + e.id() + '/color',
            data: JSON.stringify(params),
            success: function (data) {
                e.data.color = color;
                dp.events.update(e);
                dp.message("Color updated");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
    
