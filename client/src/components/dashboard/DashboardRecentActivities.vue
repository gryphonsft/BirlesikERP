<script setup>
const activities = [
    {
        id: 1,
        title: "Yeni çalışan eklendi",
        description: "Abdullah Bozdağ",
        time: "2 dk önce"
    },
    {
        id: 2,
        title: "Departman oluşturuldu",
        description: "Yazılım",
        time: "10 dk önce"
    },
    {
        id: 3,
        title: "Takım güncellendi",
        description: "Backend Team",
        time: "30 dk önce"
    },
    {
        id: 4,
        title: "Pozisyon oluşturuldu",
        description: "Senior Developer",
        time: "1 saat önce"
    }
]
</script>

<template>
    <h1 class="text-gray-500 mb-2">Aktiviteler</h1>
    <div
        class="bg-[#24242E] rounded-xl shadow-md h-[370px] overflow-hidden">

        <div class="px-5 py-4 border-b border-gray-700">
            <h2 class="text-lg font-semibold text-white">
                Son Aktiviteler
            </h2>
        </div>

        <div class="divide-y divide-gray-700">

            <div
                v-for="activity in activities"
                :key="activity.id"
                class="px-5 py-4 hover:bg-[#2d2d38] transition">

                <p class="text-white text-sm font-medium">
                    {{ activity.title }}
                </p>

                <p class="text-gray-400 text-sm">
                    {{ activity.description }}
                </p>

                <span class="text-xs text-gray-500">
                    {{ activity.time }}
                </span>

            </div>

        </div>

    </div>
</template>