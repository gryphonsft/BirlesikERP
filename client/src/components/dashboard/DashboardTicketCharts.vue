
<template>
  <div class="w-full min-w-0">
    <div class="w-full min-w-0 overflow-hidden">
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
          data: [160, 210, 240],
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
            barHeight: "70%",
            distributed: true,
            horizontal: true,
            dataLabels: {
              position: "bottom",
            },
          },
        },

        theme: {
          monochrome: {
            enabled: true,
            color: "#3974FF",
            shadeTo: "dark",
            shadeIntensity: 0.5,
          },
        },

        dataLabels: {
          enabled: true,
          textAnchor: "start",
          style: {
            colors: ["#fff"],
            fontWeight: 600,
            fontSize: "12px",
          },
          formatter(val, opt) {
            return `${opt.w.globals.labels[opt.dataPointIndex]}: ${val}`;
          },
          offsetX: 8,
        },

        legend: {
          show: false,
        },

        xaxis: {
          categories: ["Açık", "Kapalı", "Ertelendi"],
        },

        yaxis: {
          labels: {
            show: false,
          },
        },

        title: {
          text: "Destek Talepleri Grafiği",
          align: "center",
          floating: true,
          style: {
            fontSize: "14px",
          },
        },

        tooltip: {
          theme: "dark",
          x: {
            show: false,
          },
          y: {
            title: {
              formatter() {
                return "";
              },
            },
          },
        },

        responsive: [
          {
            breakpoint: 480,
            options: {
              chart: {
                height: 280,
              },
              dataLabels: {
                style: {
                  fontSize: "10px",
                },
                offsetX: 4,
              },
              title: {
                style: {
                  fontSize: "12px",
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
