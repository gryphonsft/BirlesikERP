<script setup>
import Table from '../../components/common/Table.vue';
import { Eye, SquarePen, Trash2 } from "@lucide/vue";

const columns = [
    {
        key: "firstName",
        label: "Ad"
    },
    {
        key: "lastName",
        label: "Soyad"
    },
    {
        key: "positionName",
        label: "Pozisyon adı"
    }

]
defineProps({
    employees: {
        type: Array,
        required: true
    }
})
</script>

<template>
    <div>
        <div class="flex justify-between items-center mb-4">

            <h2 class="text-2xl font-bold text-white">
                Çalışanlar
            </h2>

            <RouterLink to="" class="flex items-center gap-2 bg-white p-2 px-6 rounded-lg text-slate-950">
                Yeni Çalışan (Yapım aşamasında)
            </RouterLink>
        </div>

        <Table :columns="columns" :items="employees">

            <template #cell-isActive="{ item }">
                <span v-if="item.isActive" class="text-green-400 bg-green-600/10 p-2 px-3 
               rounded-xl border
             border-green-900">
                    Aktif
                </span>

                <span v-else class="text-yellow-400 bg-yellow-600/10 p-2 px-3 rounded-xl border
            border-yellow-500/50
            ">
                    Pasif
                </span>
            </template>

            <template #actions="{ item }">

                <div class="flex justify-end gap-2">

                    <button type="button" @click="editTeam(item)"
                        class="px-2 py-2 text-sm text-white bg-gray-600/50 rounded-lg">
                        <Eye :size="20" class="text-gray-400" />
                    </button>
                    <button type="button" @click="editTeam(item)"
                        class="px-2 py-2 text-sm text-white bg-indigo-400/60 rounded-lg">
                        <SquarePen :size="20" class="text-blue-950" />
                    </button>

                    <button type="button" @click="deleteTeam(item.id)"
                        class="px-2 py-2 text-sm text-white bg-red-500/30 rounded-lg">
                        <Trash2 :size="20" class="text-rose-700" />
                    </button>

                </div>

            </template>

        </Table>
    </div>

</template>