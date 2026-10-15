
<script setup>
import { watch } from "vue";
import { useRoute } from "vue-router";
import {
  LayoutDashboard,
  Users,
  Building2,
  Handshake,
  BriefcaseBusiness,
  UserKey,
  ScrollText,
  Folders
} from "@lucide/vue";

import logo from "@/assets/images/logo.png";

const props = defineProps({
  mobileOpen: {
    type: Boolean,
    default: false
  }
});

const emit = defineEmits(["close"]);
const route = useRoute();

watch(
  () => route.fullPath,
  () => emit("close")
);

const links = [
  { label: "Dashboard", to: "/", icon: LayoutDashboard },
  { label: "Employees", to: "/employees", icon: Users },
  { label: "Departments", to: "/departments", icon: Building2 },
  { label: "Teams", to: "/teams", icon: Handshake },
  { label: "Positions", to: "", icon: BriefcaseBusiness },
  { label: "Projects", to: "", icon: Folders },
  { label: "Roles", to: "", icon: UserKey },
  { label: "Logs", to: "", icon: ScrollText }
];
</script>

<template>
  <aside
    :class="[
      'fixed inset-y-0 left-0 z-50 flex w-72 shrink-0 flex-col',
      'border-r-2 border-gray-700 text-white',
      'transform transition-transform duration-300 ease-in-out',
      'lg:static lg:translate-x-0',
      mobileOpen ? 'translate-x-0' : '-translate-x-full'
    ]"
    style="background-color: #111827;"
  >
    <div class="flex h-20 shrink-0 items-center p-2">
      <img
        :src="logo"
        alt="BirlesikERP Logo"
        class="max-h-full max-w-full object-contain"
      />
    </div>

    <nav class="flex-1 space-y-2 overflow-y-auto p-4 text-base">
      <RouterLink
        v-for="link in links"
        :key="link.label"
        :to="link.to || route.fullPath"
        @click="emit('close')"
        class="flex w-full items-center gap-3 rounded-lg px-4 py-3
               transition-colors hover:bg-slate-800"
        :class="{
          'bg-slate-800 text-white':
            link.to && route.path === link.to
        }"
      >
        <component :is="link.icon" :size="20" />
        <span>{{ link.label }}</span>
      </RouterLink>
    </nav>
  </aside>
</template>
