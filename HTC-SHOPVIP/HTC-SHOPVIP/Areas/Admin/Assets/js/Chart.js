$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: '/Admin/Home/LayGiaTriTuCSDL',
        data: JSON.stringify({}),
        contentType: "application/json:charset=utf-8",
        dataType: 'json',
        success: function (json) {
            debugger
            var MangGiaTri = json.DuLieu;
            var GiaTri1 = parseInt(MangGiaTri[0]);
            var GiaTri2 = parseInt(MangGiaTri[1]);
            var GiaTri3 = parseInt(MangGiaTri[2]);
            var GiaTri4 = parseInt(MangGiaTri[3]);
            var GiaTri5 = parseInt(MangGiaTri[4]);
            var GiaTri6 = parseInt(MangGiaTri[5]);

            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'THỐNG KÊ SỐ LƯỢNG SẢN PHẨM ĐÃ BÁN'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Chiếm tỉ lệ',
                    colorByPoint: true,
                    data: [{
                        name: 'Điện thoại',
                        y: GiaTri1,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Máy tính bảng',
                        y: GiaTri2
                    }, {
                        name: 'Máy cũ',
                        y: GiaTri3
                    }, {
                        name: 'PC - Linh kiện',
                        y: GiaTri4
                    }, {
                        name: 'Phụ kiện',
                        y: GiaTri5
                    }, {
                        name: 'Laptop',
                        y: GiaTri6
                    }]
                }]
            });


        }
    });

});