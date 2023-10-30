import { ScreenRoute } from 'src/models/Support/global';
import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('src/pages/HowToPlay.vue') },
      {
        path: ScreenRoute.ShareSolution,
        component: () => import('src/pages/SharePage.vue'),
      },
      {
        path: ScreenRoute.HowToPlay,
        component: () => import('src/pages/HowToPlay.vue'),
      },
      {
        path: ScreenRoute.Strategy,
        component: () => import('src/pages/StrategyPage.vue'),
      },
      {
        path: ScreenRoute.PlayOffline,
        component: () => import('src/pages/PlayOffline.vue'),
      },
      {
        path: ScreenRoute.Security,
        component: () => import('src/pages/SecurityPage.vue'),
      },
      {
        path: ScreenRoute.GeekOut,
        component: () => import('src/pages/GeekOut.vue'),
      },
      {
        path: ScreenRoute.FAQ,
        component: () => import('src/pages/FAQ.vue'),
      },
      {
        path: ScreenRoute.ContactUs,
        component: () => import('src/pages/ContactUs.vue'),
      },
      {
        path: ScreenRoute.SignUp,
        component: () => import('src/pages/SignUp.vue'),
      },
      {
        path: ScreenRoute.SignIn,
        component: () => import('src/pages/SignIn.vue'),
      },
      {
        path: ScreenRoute.PlayNow,
        component: () => import('src/pages/PlayNow.vue'),
      },
      {
        path: ScreenRoute.TourOfTheDay,
        component: () => import('src/pages/TourOfTheDay.vue'),
      },
      {
        path: ScreenRoute.Logout,
        component: () => import('src/pages/LogoutPage.vue'),
      },
      {
        path: ScreenRoute.ChangePassword,
        component: () => import('src/pages/ChangePassword.vue'),
      },
      {
        path: ScreenRoute.MemberStatistics,
        component: () => import('src/pages/MemberStatistics.vue'),
      },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

export default routes;
