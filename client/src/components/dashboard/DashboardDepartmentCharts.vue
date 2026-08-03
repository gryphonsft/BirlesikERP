<template>
  <div>
    <h1 class="text-gray-500 mb-2">Grafikler</h1>
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
          name: 'Visitors',
          data: [400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380],
        },
      ],
      chartOptions: {
        chart: {
          type: 'bar',
          height: 350,
        },
        plotOptions: {
          bar: {
            borderRadius: 4,
            borderRadiusApplication: 'end',
            horizontal: true,
          },
        },
        dataLabels: {
          enabled: false,
        },
        title: {
          text: 'Departman Grafiği',
          align: 'left',
        },
        xaxis: {
          categories: [
            'South Korea',
            'Canada',
            'United Kingdom',
            'Netherlands',
            'Italy',
            'France',
            'Japan',
            'United States',
            'China',
            'Germany',
          ],
          labels: {
            formatter: function (val) {
              return val + 'k'
            },
          },
        },
      },
    }
  },
}
</script>
