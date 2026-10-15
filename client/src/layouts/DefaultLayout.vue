
<script setup>
import { ref } from "vue";
import { Menu } from "@lucide/vue";
import Sidebar from "../components/common/Sidebar.vue";

const isSidebarOpen = ref(false);
</script>

<template>
  <div
    class="flex min-h-screen lg:h-screen"
    style="background-color: #18212F;"
  >
    <header
      class="fixed inset-x-0 top-0 z-40 flex h-16 items-center gap-3
             border-b border-gray-700 px-4 text-white lg:hidden"
      style="background-color: #111827;"
    >
      <button
        type="button"
        @click="isSidebarOpen = !isSidebarOpen"
        class="flex h-10 w-10 items-center justify-center rounded-lg
               hover:bg-slate-800"
        aria-label="Menüyü aç"
        :aria-expanded="isSidebarOpen"
      >
        <Menu :size="24" />
      </button>

      <span class="text-lg font-semibold">BirlesikERP</span>
    </header>

    <button
      v-if="isSidebarOpen"
      type="button"
      @click="isSidebarOpen = false"
      class="fixed inset-0 z-40 bg-black/60 lg:hidden"
      aria-label="Menüyü kapat"
    ></button>

    <Sidebar
      :mobile-open="isSidebarOpen"
      @close="isSidebarOpen = false"
    />

    <div class="flex min-w-0 flex-1 flex-col pt-16 lg:pt-0">
      <main class="min-w-0 flex-1 overflow-y-auto">
        <RouterView />
      </main>
    </div>
  </div>
</template>
