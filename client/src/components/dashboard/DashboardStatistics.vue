<script setup>
import StatisticCard from "./StatisticCard.vue";

import {
    Users,
    Building2,
    UsersRound,
    Briefcase
} from '@lucide/vue';


defineProps({
    statistics: Object
});
</script>

<template>
    <div class="p-5">
        <h1 class="text-gray-500 mb-2">Kartlar</h1>
        <div class="grid grid-cols-6 gap-6">

            <StatisticCard title="Toplam Çalışan" :count="statistics.employeeCount" :icon="Users" />

            <StatisticCard title="Departman" :count="statistics.departmentCount" :icon="Building2" />

            <StatisticCard title="Takımlar" :count="statistics.teamCount" :icon="UsersRound" />

            <StatisticCard title="Pozisyonlar" :count="statistics.positionCount" :icon="Briefcase" />

            <StatisticCard title="Aktif Projeler" :count="statistics.positionCount" :icon="Briefcase" />

            <StatisticCard title="Kapanmış Projeler" :count="statistics.positionCount" :icon="Briefcase" />

        </div>
    </div>

</template>