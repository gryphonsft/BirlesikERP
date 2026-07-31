<script setup>
import { NIcon } from "naive-ui";
defineProps({
    title: String,
    count: Number,
    icon: Object
});
</script>

<template>

    <div class=" rounded-xl shadow-md p-6
         hover:shadow-2xl
         hover:-translate-y-1
         hover:border
         transition-all
         cursor-pointer" style="background-color: #24242E;">

        <div class="flex items-center gap-4">
            <n-icon size="36">
                <component :is="icon" />
            </n-icon>
            <h3 class="text-white text-2xl">
                {{ title }}

            </h3>
        </div>

        <h1 class="text-white text-3xl font-bold mt-2">
            {{ count }}
        </h1>

    </div>

</template>