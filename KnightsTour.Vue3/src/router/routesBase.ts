/**
 * File:     routesBase.ts
 * Location: src\router\
 * The base class for the @see router - stays in sync with the model.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */

// Imports
import { RouteRecordRaw } from 'vue-router';

/** Base routes related to the entities in the model. */
export const baseRoutes: RouteRecordRaw[] = 
[
  {
    path: '/Board',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'BoardEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/Board/pages/BoardEditPage.vue'),
      },
      {
        name: 'BoardInsert',
        path: 'insert',
        component: () =>
          import('../entities/Board/pages/BoardInsertPage.vue'),
      },
      {
        name: 'BoardList',
        path: 'list',
        component: () =>
          import('../entities/Board/pages/BoardListPage.vue'),
      },
      {
        name: 'BoardView',
        path: 'view/:id',
        component: () =>
          import('../entities/Board/pages/BoardViewPage.vue'),
      },
    ],
  },
  {
    path: '/DifficultyLevel',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'DifficultyLevelEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/DifficultyLevel/pages/DifficultyLevelEditPage.vue'),
      },
      {
        name: 'DifficultyLevelInsert',
        path: 'insert',
        component: () =>
          import('../entities/DifficultyLevel/pages/DifficultyLevelInsertPage.vue'),
      },
      {
        name: 'DifficultyLevelList',
        path: 'list',
        component: () =>
          import('../entities/DifficultyLevel/pages/DifficultyLevelListPage.vue'),
      },
      {
        name: 'DifficultyLevelView',
        path: 'view/:id',
        component: () =>
          import('../entities/DifficultyLevel/pages/DifficultyLevelViewPage.vue'),
      },
    ],
  },
  {
    path: '/EventHistory',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'EventHistoryEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/EventHistory/pages/EventHistoryEditPage.vue'),
      },
      {
        name: 'EventHistoryInsert',
        path: 'insert',
        component: () =>
          import('../entities/EventHistory/pages/EventHistoryInsertPage.vue'),
      },
      {
        name: 'EventHistoryList',
        path: 'list',
        component: () =>
          import('../entities/EventHistory/pages/EventHistoryListPage.vue'),
      },
      {
        name: 'EventHistoryView',
        path: 'view/:id',
        component: () =>
          import('../entities/EventHistory/pages/EventHistoryViewPage.vue'),
      },
    ],
  },
  {
    path: '/EventType',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'EventTypeEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/EventType/pages/EventTypeEditPage.vue'),
      },
      {
        name: 'EventTypeInsert',
        path: 'insert',
        component: () =>
          import('../entities/EventType/pages/EventTypeInsertPage.vue'),
      },
      {
        name: 'EventTypeList',
        path: 'list',
        component: () =>
          import('../entities/EventType/pages/EventTypeListPage.vue'),
      },
      {
        name: 'EventTypeView',
        path: 'view/:id',
        component: () =>
          import('../entities/EventType/pages/EventTypeViewPage.vue'),
      },
    ],
  },
  {
    path: '/Member',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'MemberEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/Member/pages/MemberEditPage.vue'),
      },
      {
        name: 'MemberInsert',
        path: 'insert',
        component: () =>
          import('../entities/Member/pages/MemberInsertPage.vue'),
      },
      {
        name: 'MemberList',
        path: 'list',
        component: () =>
          import('../entities/Member/pages/MemberListPage.vue'),
      },
      {
        name: 'MemberView',
        path: 'view/:id',
        component: () =>
          import('../entities/Member/pages/MemberViewPage.vue'),
      },
    ],
  },
  {
    path: '/Puzzle',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'PuzzleEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/Puzzle/pages/PuzzleEditPage.vue'),
      },
      {
        name: 'PuzzleInsert',
        path: 'insert',
        component: () =>
          import('../entities/Puzzle/pages/PuzzleInsertPage.vue'),
      },
      {
        name: 'PuzzleList',
        path: 'list',
        component: () =>
          import('../entities/Puzzle/pages/PuzzleListPage.vue'),
      },
      {
        name: 'PuzzleView',
        path: 'view/:id',
        component: () =>
          import('../entities/Puzzle/pages/PuzzleViewPage.vue'),
      },
    ],
  },
  {
    path: '/Solution',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'SolutionEdit',
        path: 'edit/:id',
        component: () =>
          import('../entities/Solution/pages/SolutionEditPage.vue'),
      },
      {
        name: 'SolutionInsert',
        path: 'insert',
        component: () =>
          import('../entities/Solution/pages/SolutionInsertPage.vue'),
      },
      {
        name: 'SolutionList',
        path: 'list',
        component: () =>
          import('../entities/Solution/pages/SolutionListPage.vue'),
      },
      {
        name: 'SolutionView',
        path: 'view/:id',
        component: () =>
          import('../entities/Solution/pages/SolutionViewPage.vue'),
      },
    ],
  },
  {
    path: '/',
    component: () => import('../common/layouts/Authenticated.vue'),
    children: [
      {
        name: 'Home',
        path: '',
        component: () => import('../common/pages/Home.vue'),
      },
    ],
  },
  {
    path: '/:catchAll(.*)*',
    component: () => import('../common/pages/ErrorNotFound.vue'),
  },
]
