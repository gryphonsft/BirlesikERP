<script setup>
import { ref, onMounted } from "vue";
import { getStatisctics } from "../services/dashboardService";
import DashboardStatistics from "../components/dashboard/DashboardStatistics.vue";
import DashboardHeader from "../components/dashboard/DashboardHeader.vue";


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

    </div>

</template>
<style scoped>

</style>