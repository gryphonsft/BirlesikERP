import { createRouter, createWebHistory } from "vue-router";

import DefaultLayout from "../layouts/DefaultLayout.vue";

import DashboardView from "../views/Dashboard/DashboardView.vue";
import EmployeeView from "../views/Employee/EmployeeView.vue";
import DepartmentView from "../views/Department/DepartmentView.vue";
import DepartmentAddView from "../views/Department/DepartmentAddView.vue";
import TeamView from "../views/Team/TeamView.vue";
import TeamAddView from "../views/Team/TeamAddView.vue";
import PositionView from "../views/Position/PositionView.vue";
import RolesView from "../views/Role/RolesView.vue";


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
        },
        {
          path:"departments/add",
          component: DepartmentAddView
        },
        {
          path:"teams",
          component: TeamView
        },
        {
          path:"teams/add",
          component: TeamAddView
        },
        {
          path:"positions",
          component: PositionView
        },
        {
          path:"roles",
          component: RolesView
        },        
      ],
    },
  ],
});

export default router;