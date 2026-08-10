<script setup>
import Table from '../../components/common/Table.vue';

const columns = [
    {
        key: 'id',
        label: 'Id'
    },
    {
        key: 'name',
        label: 'Takım Adı'
    },
    {
        key: 'description',
        label: 'Açıklaması'
    },
    {
        key: 'isActive',
        label: 'Durumu'
    },
    {
        key: 'createdAt',
        label: 'Oluşturulma Tarihi'
    }
]

defineProps({
    teams: {
        type: Array,
        required: true
    }
})
</script>
<template>

    <div class="flex justify-between items-center mb-4">

        <h2 class="text-2xl font-bold text-white">
            Takımlar
        </h2>

        <RouterLink to="teams/add" class="flex items-center gap-2 bg-white p-2 px-6 rounded-lg text-slate-950">
            Yeni Takım
        </RouterLink>

    </div>

    <Table :columns="columns" :items="teams" />

</template>