<template>
  <div class="keepsComponent card mb-2 imageFit" :data-target="'#keep-modal-'+keepProp.id" data-toggle="modal" :style="{backgroundImage:`url(${keepProp.img})`}">
    <h4>
      {{ keepProp.name }}
    </h4>
  </div>
  <!-- <button type="button" class="btn btn-primary" data-toggle="modal" :data-target="'#keep-modal-'+keepProp.id">
    Launch demo modal
  </button> -->
  <!-- Modal -->
  <div class="modal fade"
       :id="'keep-modal-'+keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <button type="button" class="close text-right pr-2" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <div class="row">
          <div class="col-6">
            test
            <img src="{{keepProp.Img}}">
          </div>
          <div class="col-6">
            {{ keepProp.name }}
          </div>
        </div>
        <div class="modal-footer">
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <DropdownComponent v-for="vault in state.vaults" :key="vault.id" :vault-props="vault" :list-prop="listProp" />
          </div>
          <i class="fa fa-trash-o text-center" aria-hidden="true"></i>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'KeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      vaults: computed(() => AppState.vaults.filter(l => l.id !== props.keepProp.vault))
    })
    return { state }
  }
}
</script>

<style scoped>
.imageFit{
  height: 100%;
  width: 100%;
  object-fit: cover;
  }

</style>
