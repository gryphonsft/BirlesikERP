<script setup>

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
    <table class="w-full border-separate border-spacing-0 overflow-hidden rounded-xl">
        <thead class="bg-[#26262A] text-white">
            <tr>
                <th v-for="column in columns" :key="column.key" class="p-4 text-left">
                    {{ column.label }}
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in items" :key="item.id" class="text-lg text-white transition-all duration-200">
                <td v-for="column in columns" :key="column.key" class="p-4 border-b border-gray-200">
                    {{ item[column.key] }}
                </td>
            </tr>
        </tbody>
    </table>
</template>