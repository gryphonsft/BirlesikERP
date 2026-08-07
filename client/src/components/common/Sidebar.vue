<script setup>
import {
    LayoutDashboard,
    Users,
    Building2,
    Handshake,
    BriefcaseBusiness,
    UserKey,
    ScrollText,
    Folders
} from '@lucide/vue';
import logo from '@/assets/images/logo.png';
</script>
<template>

    <aside class="w-72 bg-gray-800 border-r-2 border-gray-700 text-white flex flex-col"
        style="background-color: #111827;">

        <div class="p-2 flex items-center ">
            <img :src="logo" alt="Logo">
        </div>

        <nav class="flex-1 p-6 space-y-2 items-center text-lg">

            <div class="flex items-center">

                <RouterLink to="/" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <LayoutDashboard />
                    Dashboard

                </RouterLink>
            </div>

            <div class="flex items-center">
                <RouterLink to="/employees" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <Users />
                    Employees

                </RouterLink>
            </div>

            <div class="flex items-center">
                <RouterLink to="/departments" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <Building2 />
                    Departments

                </RouterLink>
            </div>
            <div class="flex items-center">
                <RouterLink to="/teams" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <Handshake />
                    Teams
                </RouterLink>
            </div>
            <div class="flex items-center">
                <RouterLink to="/positions" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <BriefcaseBusiness />
                    Positions
                </RouterLink>
            </div>
            <div class="flex items-center">
                <RouterLink to="/projects" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <Folders />
                    Projects
                </RouterLink>
            </div>
            <div class="flex items-center">
                <RouterLink to="/roles" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <UserKey />
                    Roles
                </RouterLink>
            </div>
            <div class="flex items-center">
                <RouterLink to="/logs" class="flex items-center rounded-lg px-4 py-3 gap-2 hover:bg-slate-800">
                    <ScrollText />
                    Logs
                </RouterLink>
            </div>

        </nav>

    </aside>

</template>
