
<script setup>
import { ref, onMounted } from "vue";
import { getStatisctics } from "../../services/dashboardService.js";

import DashboardStatistics from "../../components/dashboard/DashboardStatistics.vue";
import DashboardHeader from "../../components/dashboard/DashboardHeader.vue";
import DashboardDepartmentCharts from "../../components/dashboard/DashboardDepartmentCharts.vue";
import DashboardTicketCharts from "../../components/dashboard/DashboardTicketCharts.vue";
import DashboardRecentActivities from "../../components/dashboard/DashboardRecentActivities.vue";

const statistics = ref({
  employeeCount: 0,
  departmentCount: 0,
  teamCount: 0,
  positionCount: 0
});

async function loadStatistics() {
  const response = await getStatisctics();
  statistics.value = response.data;
}

onMounted(async () => {
  await loadStatistics();
});
</script>

<template>
  <div class="page min-w-0 w-full">

    <!-- Sayfa başlığı -->
    <DashboardHeader />

    <!-- İstatistik kartları -->
    <DashboardStatistics :statistics="statistics" />

    <!-- Grafikler ve son aktiviteler -->
    <div
      class="grid min-w-0 grid-cols-1 gap-5 px-4 pb-5 sm:px-5 xl:grid-cols-2 2xl:grid-cols-[minmax(0,1fr)_minmax(0,1fr)_320px]"
    >

      <!-- Departman grafikleri -->
      <div class="min-w-0">
        <DashboardDepartmentCharts />
      </div>

      <!-- Talep grafikleri -->
      <div class="min-w-0">
        <DashboardTicketCharts />
      </div>

      <!-- Son aktiviteler -->
      <div class="min-w-0 xl:col-span-2 2xl:col-span-1">
        <DashboardRecentActivities />
      </div>

    </div>
  </div>
</template>
