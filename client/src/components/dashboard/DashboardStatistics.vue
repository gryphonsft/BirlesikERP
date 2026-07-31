<script setup>
import StatisticCard from "./StatisticCard.vue";
import {
    PeopleAltRound,
    BusinessFilled,
    GroupsFilled,
    WorkFilled
} from "@vicons/material";


defineProps({
    statistics: Object
});
</script>

<template>

    <div class="p-5">
        <div class="grid grid-cols-4 gap-6">

            <StatisticCard title="Çalışanlar" :count="statistics.employeeCount" :icon="PeopleAltRound" />

            <StatisticCard title="Departmanlar" :count="statistics.departmentCount" :icon="BusinessFilled" />

            <StatisticCard title="Takımlar" :count="statistics.teamCount" :icon="GroupsFilled" />

            <StatisticCard title="Pozisyonlar" :count="statistics.positionCount" :icon="WorkFilled" />

        </div>
    </div>
</template>