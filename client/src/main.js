import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./style.css";
import "@fontsource/inter";
import VueApexCharts from "vue3-apexcharts";

const app = createApp(App);

app.use(router);
app.use(VueApexCharts);

app.mount("#app");
