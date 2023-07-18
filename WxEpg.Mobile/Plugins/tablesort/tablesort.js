/*******************************************************************************
* tablesort
* Copyright (C) 2016
* @name '表格排序插件'
* @author caojianping/曹剑平
* @version 1.0.0.0 (2016-1-25)
*******************************************************************************/
; (function ($, window, document, undefined) {
    var defaults = {};

    var TableSorter = function (element, options) {
        this.$elements = element;
        this.settings = $.extend({}, defaults, options);
    };

    TableSorter.prototype = {
        //创建排序按钮
        createButton: function (sorts) {
            $(sorts).each(function (index, element) {
                var span = $(element).children("span");
                if (span.length > 0) span.remove();
                $(element).append('<span class="bsort"></span>');
            });
        },
        //自定义排序
        customSort: function () {
            var $this = this;
            $(document).on("click", ".bsort", function () {
                var th = $(this).parent();
                if (th.length <= 0) return;

                var index = th.index();
                var type = th.data("type");

                var tbl = $(this).parents("table");
                var tbody = tbl.children("tbody");
                var rows = tbody.children("tr");
                var temp = new Array();
                for (var i = 0; i < rows.length; i++) {
                    temp[i] = rows[i];
                }
                //判断排序列的索引
                if (tbl.data("current") == index) {
                    temp.reverse();                    
                } else {
                    temp.sort($this.customCompare(index, type));                    
                }
                tbody.empty();
                for (var i = 0; i < temp.length; i++) {
                    tbody.append(temp[i]);
                }
                tbl.data("current", index);
            });
        },
        //自定义比较算法
        customCompare: function (index, type) {
            var $this = this;
            return function (r1, r2) {
                var v1 = $this.customConvert($(r1).children("td").eq(index).text().trim(), type);
                var v2 = $this.customConvert($(r2).children("td").eq(index).text().trim(), type);
                if (v1 > v2) {
                    return 1;
                } else if (v1 < v2) {
                    return -1;
                } else {
                    return 0;
                }
            };
        },
        //自定义类型转换
        customConvert: function (dataValue, dataType) {
            switch (dataType) {
                case "int":
                    return parseInt(dataValue);
                case "float":
                    return parseFloat(dataValue);
                case "date":
                    return new Date(Date.parse(dataValue));
                case "string":
                    return dataValue.toString();
                default:
                    return dataValue.toString();
            }
        },
        //表格排序
        tableSort: function () {
            var $this = this;
            return $this.$elements.each(function (index, element) {
                var sorts = $(element).find("thead th.sort");
                if (sorts.length > 0) {
                    $this.createButton(sorts);
                    $this.customSort();
                }
            });
        },
    };

    $.fn.extend({
        tableSort: function (options) {
            return new TableSorter(this, options).tableSort();
        }
    });

})(jQuery, window, document);