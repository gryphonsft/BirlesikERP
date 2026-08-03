<script setup>
import { ref, onMounted } from "vue";
import { getStatisctics } from "../services/dashboardService";
import DashboardStatistics from "../components/dashboard/DashboardStatistics.vue";
import DashboardHeader from "../components/dashboard/DashboardHeader.vue";
import DashboardDepartmentCharts from "../components/dashboard/DashboardDepartmentCharts.vue";
import DashboardTicketCharts from "../components/dashboard/DashboardTicketCharts.vue";
import DashboardRecentActivities from "../components/dashboard/DashboardRecentActivities.vue";
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
})
</script>

<template>

    <div class="page">

        <DashboardHeader />
        <DashboardStatistics :statistics="statistics" />
        <div class="flex gap-6 px-5 pb-5">

            <div class="flex-1">
                <DashboardDepartmentCharts />
            </div>

            <div class="flex-1">
                <DashboardTicketCharts />
            </div>

            <div class="w-100">
                <DashboardRecentActivities />
            </div>

        </div>
    </div>

</template>
