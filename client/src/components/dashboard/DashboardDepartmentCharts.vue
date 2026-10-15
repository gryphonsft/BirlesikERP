
<template>
  <div class="w-full min-w-0">
    <h1 class="mb-2 text-gray-500">Grafikler</h1>

    <div
      id="chart"
      class="w-full min-w-0 overflow-hidden rounded-xl"
    >
      <apexchart
        type="bar"
        height="300"
        width="100%"
        :options="chartOptions"
        :series="series"
      />
    </div>
  </div>
</template>

<script>
import VueApexCharts from "vue3-apexcharts";

export default {
  components: {
    apexchart: VueApexCharts,
  },

  data() {
    return {
      series: [
        {
          name: "Visitors",
          data: [400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380],
        },
      ],

      chartOptions: {
        chart: {
          type: "bar",
          height: 300,
          toolbar: {
            show: false,
          },
          redrawOnParentResize: true,
          redrawOnWindowResize: true,
        },

        plotOptions: {
          bar: {
            borderRadius: 4,
            borderRadiusApplication: "end",
            horizontal: true,
          },
        },

        dataLabels: {
          enabled: false,
        },

        title: {
          text: "Departman Grafiği",
          align: "left",
        },

        xaxis: {
          categories: [
            "South Korea",
            "Canada",
            "United Kingdom",
            "Netherlands",
            "Italy",
            "France",
            "Japan",
            "United States",
            "China",
            "Germany",
          ],

          labels: {
            formatter(val) {
              return val + "k";
            },
          },
        },

        responsive: [
          {
            breakpoint: 480,
            options: {
              chart: {
                height: 350,
              },
              title: {
                style: {
                  fontSize: "14px",
                },
              },
              yaxis: {
                labels: {
                  style: {
                    fontSize: "10px",
                  },
                },
              },
            },
          },
        ],
      },
    };
  },
};
</script>
