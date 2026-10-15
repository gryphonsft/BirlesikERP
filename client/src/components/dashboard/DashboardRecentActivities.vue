
<script setup>
const activities = [
  {
    id: 1,
    title: "Yeni çalışan eklendi",
    description: "Abdullah Bozdağ",
    time: "2 dk önce",
  },
  {
    id: 2,
    title: "Departman oluşturuldu",
    description: "Yazılım",
    time: "10 dk önce",
  },
  {
    id: 3,
    title: "Takım güncellendi",
    description: "Backend Team",
    time: "30 dk önce",
  },
  {
    id: 4,
    title: "Pozisyon oluşturuldu",
    description: "Senior Developer",
    time: "1 saat önce",
  },
];
</script>

<template>
  <section class="w-full min-w-0">
    <h1 class="mb-2 text-gray-500">Aktiviteler</h1>

    <div
      class="h-auto min-h-[300px] w-full min-w-0 overflow-hidden rounded-xl bg-[#24242E] shadow-md sm:min-h-[370px]"
    >
      <div class="border-b border-gray-700 px-4 py-4 sm:px-5">
        <h2 class="text-lg font-semibold text-white">
          Son Aktiviteler
        </h2>
      </div>

      <div class="divide-y divide-gray-700">
        <div
          v-for="activity in activities"
          :key="activity.id"
          class="px-4 py-4 transition hover:bg-[#2d2d38] sm:px-5"
        >
          <p class="break-words text-sm font-medium text-white">
            {{ activity.title }}
          </p>

          <p class="mt-1 break-words text-sm text-gray-400">
            {{ activity.description }}
          </p>

          <span class="mt-1 block text-xs text-gray-500">
            {{ activity.time }}
          </span>
        </div>
      </div>
    </div>
  </section>
</template>
