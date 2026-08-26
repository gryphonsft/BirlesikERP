<script setup>
import Sidebar from "../components/common/Sidebar.vue";
</script>

<template>
  <div class="flex h-screen" style="background-color: #18212F;">

    <Sidebar />

    <div class="flex flex-1 flex-col">
      <main class="flex-1 overflow-y-auto">
        <RouterView />
      </main>
    </div>

  </div>
</template>