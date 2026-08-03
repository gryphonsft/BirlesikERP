<template>
  <div>
    
    <div id="chart">
      <apexchart
        type="bar"
        height="300"
        width="500"
        :options="chartOptions"
        :series="series"
      ></apexchart>
    </div>
  </div>
</template>

<script>
import VueApexCharts from 'vue3-apexcharts'


export default {
  components: {
    apexchart: VueApexCharts,
  },
  data: function () {
    return {
      series: [
        {
          data: [160, 210, 240],
        },
      ],
      chartOptions: {
        chart: {
          type: 'bar',
          height: 380,
        },
        plotOptions: {
          bar: {
            barHeight: '100%',
            distributed: true,
            horizontal: true,
            dataLabels: {
              position: 'bottom',
            },
          },
        },
        theme: {
          monochrome: {
            enabled: true,
            color: '#3974FF',
            shadeTo: 'dark',
            shadeIntensity: 0.5,
          },
        },
        dataLabels: {
          enabled: true,
          textAnchor: 'start',
          style: {
            colors: ['#fff'],
            fontWeight: 600,
          },
          formatter: function (val, opt) {
            return opt.w.globals.labels[opt.dataPointIndex] + ':  ' + val
          },
          offsetX: 8,
        },
        legend: {
          show: false,
        },
        xaxis: {
          categories: [
      'Açık',
      'Kapalı',
      'Ertelendi'
          ],
        },
        yaxis: {
          labels: {
            show: false,
          },
        },
        title: {
          text: 'Destek Talepleri Grafiği',
          align: 'center',
          floating: true,
        },
        tooltip: {
          theme: 'white',
          x: {
            show: false,
          },
          y: {
            title: {
              formatter: function () {
                return ''
              },
            },
          },
        },
      },
    }
  },
}
</script>

<style>
#chart {
  max-width: 650px;
  margin: 35px auto;
}
</style>
