<script setup>
import { ref } from "vue";
import { Users, Search, Folders, CircleCheck, ChevronDown, RefreshCcw } from "@lucide/vue";
defineProps({
    columns: {
        type: Array,
        required: true
    }, items: {
        type: Array,
        required: true
    }
});

</script>
<template>
    <div class="grid w-full grid-cols-4 gap-6">

        <div class="flex h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
            style="background-color: #1C2532;">
            <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl"
                style="background-color: #42248A;">
                <Users :size="24" class="text-purple-300" />
            </div>

            <div class="min-w-0 flex-1">
                <p class="text-xs text-slate-400">
                    Toplam Takım
                </p>

                <p class="mt-1 text-2xl font-bold text-white">
                    12
                </p>

                <p class="mt-1 text-xs text-slate-400">
                    Aktif takımlar
                </p>
            </div>
        </div>

        <div class="flex h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
            style="background-color: #1C2532;">
            <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-blue-400">
                <Users :size="24" class="text-blue-950" />
            </div>

            <div class="min-w-0 flex-1">
                <p class="text-xs text-slate-400">
                    Toplam Kullanıcı
                </p>

                <p class="mt-1 text-2xl font-bold text-white">
                    128
                </p>

                <p class="mt-1 text-xs text-slate-400">
                    Aktif kullanıcılar
                </p>
            </div>

            <div class="self-end pb-1 text-xs font-medium text-green-400">
                ↑ 8%
            </div>
        </div>

        <div class="flex h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
            style="background-color: #1C2532;">
            <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-yellow-400">
                <Folders :size="24" class="text-yellow-950" />
            </div>

            <div class="min-w-0 flex-1">
                <p class="text-xs text-slate-400">
                    Aktif Projeler
                </p>

                <p class="mt-1 text-2xl font-bold text-white">
                    24
                </p>

                <p class="mt-1 text-xs text-slate-400">
                    Devam eden projeler
                </p>
            </div>

            <div class="self-end pb-1 text-xs font-medium text-green-400">
                ↑ 15%
            </div>
        </div>

        <div class="flex h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
            style="background-color: #1C2532;">
            <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-green-700">
                <CircleCheck :size="24" class="text-green-950" />
            </div>

            <div class="min-w-0 flex-1">
                <p class="text-xs text-slate-400">
                    Tamamlanan
                </p>

                <p class="mt-1 text-2xl font-bold text-white">
                    86
                </p>

                <p class="mt-1 text-xs text-slate-400">
                    Tamamlanan işler
                </p>
            </div>

            <div class="self-end pb-1 text-xs font-medium text-green-400">
                ↑ 21%
            </div>
        </div>

    </div>

    <div class="rounded-lg p-4 mt-10 border border-slate-700/50" style="background-color: #1C2532;">
        <div class="flex items-end gap-8">
            <div class="relative w-80">
                <input type="text" placeholder="Takım adı veya açıklama ara..." class="w-full pl-5 pr-10 py-2.5 bg-gray-800 border 
                    border-gray-700 rounded-xl text-sm text-white
                     placeholder-white focus:outline-none focus:ring-1" />

                <div class="absolute inset-y-0 right-3 flex items-center pointer-events-none">
                    <Search class="w-5 h-5 text-gray-400" />
                </div>
            </div>

            <div class="flex flex-col gap-1">
                <label class="text-xs text-gray-400">
                    Durum
                </label>

                <div class="relative w-50">
                    <select class="appearance-none w-full pl-3 pr-8 py-2.5 bg-gray-800
                       border border-gray-700 rounded-lg text-sm text-gray-200
                       focus:outline-none focus:ring-1">
                        <option value="">Tümü</option>
                        <option value="active">Aktif</option>
                        <option value="passive">Pasif</option>
                    </select>

                    <ChevronDown class="absolute right-2 top-1/2 -translate-y-1/2
                       w-4 h-4 text-gray-400 pointer-events-none" />
                </div>
            </div>

            <div class="flex flex-col gap-1">
                <label class="text-xs text-gray-400">
                    Departman
                </label>

                <div class="relative w-50">
                    <select class="appearance-none w-full pl-3 pr-8 py-2.5 bg-gray-800
                       border border-gray-700 rounded-lg text-sm text-gray-200
                       focus:outline-none focus:ring-1">
                        <option value="">Tümü</option>
                    </select>

                    <ChevronDown class="absolute right-2 top-1/2 -translate-y-1/2
                       w-4 h-4 text-gray-400 pointer-events-none" />
                </div>
            </div>

            <div class="flex flex-col gap-1 ml-auto mr-4">
                <button
                    class="border border-gray-700 flex text-sm items-center bg-gray-800 text-white p-3 rounded-lg hover:bg-gray-700">
                    <RefreshCcw :size="20" class="mr-2" />
                    Filtreleri Temizle
                </button>
            </div>


        </div>

        <table class="mt-5 w-full text-base overflow-hidden rounded-xl border-separate border-spacing-0"
            style="background-color: #1C2532;">
            <thead class="text-white" style="background-color: #252D3B;">
                <tr>
                    <th v-for="column in columns" :key="column.key" class="p-4 text-left">
                        {{ column.label }}
                    </th>
                    <th>
                        İşlemler
                    </th>
                </tr>
            </thead>

            <tbody class="text-white">
                <tr v-for="item in items" :key="item.id" class="transition-all duration-200 hover:bg-slate-800/40">
                    <td v-for="column in columns" :key="column.key" class="p-4">
                        <slot :name="`cell-${column.key}`" :item="item">
                            {{ item[column.key] }}
                        </slot>
                    </td>
                    <td class="p-4">
                        <slot name="actions" :item="item" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="footer border-t border-gray-700">
            <h1 class="p-4 text-slate-400">
                Toplam 15 kayıt
            </h1>
        </div>
    </div>

</template>