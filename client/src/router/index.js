import { createRouter, createWebHistory } from "vue-router";

import DefaultLayout from "../layouts/DefaultLayout.vue";

import DashboardView from "../views/DashboardView.vue";
import EmployeeView from "../views/EmployeeView.vue";
import DepartmentView from "../views/DepartmentView.vue";

const router = createRouter({
  history: createWebHistory(),

  routes: [
    {
      path: "/",
      component: DefaultLayout,

      children: [
        {
          path: "",
          component: DashboardView,
        },

        {
          path: "employees",
          component: EmployeeView,
        },
        {
          path:"departments",
          component: DepartmentView
        }
      ],
    },
  ],
});

export default router;