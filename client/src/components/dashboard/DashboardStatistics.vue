
<script setup>
import StatisticCard from "./StatisticCard.vue";

import {
  Users,
  Building2,
  UsersRound,
  Briefcase,
} from "@lucide/vue";

defineProps({
  statistics: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <section class="w-full min-w-0 p-4 sm:p-5">
    <h1 class="mb-2 text-gray-500">Kartlar</h1>

    <div
      class="grid min-w-0 grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3 2xl:grid-cols-6"
    >
      <StatisticCard
        title="Toplam Çalışan"
        :count="statistics.employeeCount"
        :icon="Users"
      />

      <StatisticCard
        title="Departman"
        :count="statistics.departmentCount"
        :icon="Building2"
      />

      <StatisticCard
        title="Takımlar"
        :count="statistics.teamCount"
        :icon="UsersRound"
      />

      <StatisticCard
        title="Pozisyonlar"
        :count="statistics.positionCount"
        :icon="Briefcase"
      />

      <StatisticCard
        title="Aktif Projeler"
        :count="statistics.positionCount"
        :icon="Briefcase"
      />

      <StatisticCard
        title="Kapanmış Projeler"
        :count="statistics.positionCount"
        :icon="Briefcase"
      />
    </div>
  </section>
</template>
