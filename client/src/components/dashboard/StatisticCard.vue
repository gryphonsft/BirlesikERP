
<script setup>
defineProps({
  title: {
    type: String,
    default: "",
  },
  count: {
    type: Number,
    default: 0,
  },
  icon: {
    type: [Object, Function],
    required: true,
  },
});
</script>

<template>
  <div
    class="min-w-0 rounded-xl p-4 shadow-md transition-all duration-200 hover:-translate-y-1 hover:shadow-2xl sm:p-5 lg:p-6"
    style="background-color: #24242E;"
  >
    <div class="flex min-w-0 items-center gap-3 sm:gap-4">
      <component
        :is="icon"
        :size="32"
        color="#fff"
        class="shrink-0 sm:!h-9 sm:!w-9"
      />

      <h3 class="min-w-0 break-words text-base font-medium text-white sm:text-lg lg:text-xl">
        {{ title }}
      </h3>
    </div>

    <h2 class="mt-3 break-words text-2xl font-bold text-white sm:mt-2 sm:text-3xl">
      {{ count }}
    </h2>
  </div>
</template>
