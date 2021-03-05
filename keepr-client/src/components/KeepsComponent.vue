<template>
  <div class="keepsComponent card mb-2" :data-target="'#keep-modal-'+keepProp.id" data-toggle="modal">
    <img :src="keepProp.img" class="img-fluid">
    <h4 class="textPosition text-white mr-3">
      {{ keepProp.name }}
      <i class="fa fa-user ml-5" aria-hidden="true"></i>
    </h4>
  </div>
  <!-- Modal -->
  <div class="modal"
       :id="'keep-modal-'+keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="Close"
       aria-hidden="true"
  >
    <div class="modal-fullscreen" role="document">
      <div class="modal-content">
        <button type="button" class="close text-right pr-2" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <div class="row">
          <div class="col-6">
            <img class="img-fluid mb-2 ml-1" :src="keepProp.img">
          </div>
          <div class="col-6 text-center">
            <i class="fa fa-eye mb-3" aria-hidden="true"></i>
            {{ keepProp.views }}
            <i class="fa fa-folder-open-o ml-3" aria-hidden="true"></i>
            {{ keepProp.keeps }}
            <i class="fa fa-share-alt ml-3" aria-hidden="true"></i>
            {{ keepProp.shares }}
            <div>
              <h2 class="mb-3">
                {{ keepProp.name }}
              </h2>
            </div>
            <div>
              {{ keepProp.description }}
            </div>
            <div class="modal-footer col-12 d-flex justify-content-around align-content flex-end">
              <div class="dropdown">
                <button class="btn toggler dropdown-toggle button"
                        type="button"
                        id="dropdownMenuButton"
                        data-toggle="dropdown"
                >
                  Put task in Vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <DropdownComponent class="btn btn-outline-success" v-for="vault in state.myVaults" :key="vault.id" :vault-props="vault" :keep-prop="keepProp" />
                </div>
              </div>
              <i class="fa fa-trash-o fa-2x text-danger" v-if="state.account.id == keepProp.creatorId" @click="deleteKeep" aria-hidden="true"></i>
              <router-link :to="{name: 'ProfilePage', params: {id: keepProp.creator.id }}">
                <img class="mr-1" :src="keepProp.creator.picture" height="35">{{ keepProp.creator.name }}
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
// import { vaultsService } from '../services/VaultsService'
// import { AppState } from '../AppState'
export default {
  name: 'KeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults)
    })
    return {
      state,
      deleteKeep() {
        try {
          keepsService.deleteKeep(props.keepProp)
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style scoped>
/* .imageFit{
  height: 100%;
  width: 100%;
  object-fit: contain;
  } */

.modal-footer{
  position: absolute;
  bottom: 0;
}

.keepsComponent {
  position: relative;
}

.textPosition {
  position: absolute;
  bottom: 0px;
  left: 4px;
  font-size: 18px;
}

</style>
