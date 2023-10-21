<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">Statistics</h3>
    <q-table
      title="Your all-time statistics:"
      :rows="rows"
      :columns="cols"
      row-key="name"
      dark
      :filter="filter"
      :rows-per-page-options="[0]"
      :hide-pagination="true"
    >
      <template v-slot:top-left>
        <q-input
          borderless
          dense
          debounce="300"
          v-model="filter"
          placeholder="Filter (e.g. Easy, Longest, Average, etc.)"
          dark
          style="width: 500px; background-color: dimgrey; padding-left: 10px"
        >
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input> </template
    ></q-table>
  </div>
</template>

<script lang="ts">
import { QSelectOption, QTableProps, SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { UtilityInstance } from 'src/models/Support/global';
import { ref } from 'vue';

export default {
  Name: 'MemberStatistics',
  setup() {
    const api = new ApiService();
    const cols = ref([] as QTableProps['columns']);
    const member = ref(new Member());
    const utilityInstance = UtilityInstance;
    const rows = ref([] as QSelectOption[]);
    const filter = ref('');

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
      api
        .getMemberStatistics(member.value.memberId)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            rows.value = response.dataObject;
          } else {
            utilityInstance.toastResponse(response);
          }
        });
    }

    cols.value?.push({
      name: 'value',
      label: 'Description',
      align: 'left',
      field: 'value',
      sortable: true,
    });
    cols.value?.push({
      name: 'label',
      label: 'Value',
      align: 'left',
      field: 'label',
      sortable: true,
    });

    return {
      cols,
      rows,
      filter,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
