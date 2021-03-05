<template>
  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center"> -->
  <div class="container-fluid ProfilePage">
    <div class="row">
      <div class="col-2"></div>
      <div class="col-4"></div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3>Vaults <i class="fa fa-plus text-success" aria-hidden="true" data-toggle="modal" data-target="#exampleModal"></i></h3>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h2 class="modal-title" id="exampleModalLabel">
                  New Vault
                </h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <form action="form-inline border justify-content-center align-items-center" @submit.prevent="createVault">
                  <div class="row">
                    <div class="col-12">
                      <h5>Title</h5>
                      <input
                        type="text"
                        name="title"
                        id="title"
                        v-model="state.newVault.Name"
                        class="form-control d-flex"
                        placeholder="Title..."
                      />
                    </div>
                    <div class="col-12">
                      <h5>Description</h5>
                      <input
                        type="text"
                        name="Description"
                        id="Description"
                        v-model="state.newVault.Description"
                        class="form-control d-flex"
                        placeholder="Description..."
                      />
                    </div>
                    <div class="col-2 mt-3">
                      <input
                        type="checkbox"
                        name="checkbox"
                        id="checkbox"
                        v-model="state.newVault.IsPrivate"
                        class="form-control d-flex"
                      />
                    </div>
                    <div class="col-10 mt-3">
                      <h5>Make Private?</h5>
                    </div>
                  </div>
                </form>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">
                  Close
                </button>
                <button type="button" class="btn btn-primary" @click="createVault">
                  Save changes
                </button>
              </div>
            </div>
          </div>
        </div>
        <!-- END MODAL -->
        <div class="row">
          <div class="col-12">
            <div class="masonry-custom mt-2">
              <myVaults-component class="item" v-for="r in state.vaults" :key="r.id" :vault-prop="r">
              </myVaults-component>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3>Keeps <i class="fa fa-plus text-success" aria-hidden="true"></i></h3>
      </div>
      <div class="col-12">
        <div class="masonry">
          <myKeeps-component v-for="r in state.keeps" :key="r.id" :keep-prop="r">
          </myKeeps-component>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.myKeeps),
      newVault: {
        Name: '',
        Description: '',
        IsPrivate: false,
        creatorId: route.params.id
      }
    })
    onMounted(async() => {
      try {
        await vaultsService.getMyVaults(route.params.id)
      } catch (error) {
        logger.log(error)
      }
      try {
        await keepsService.getMyKeeps(route.params.id)
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state,
      async createVault() {
        try {
          console.log('this is your new vault', state.newVault)
          await vaultsService.createVault(state.newVault, route.params.id)
        } catch (error) {
          logger.error(error)
        }
      }
    }
  }
}
</script>

<style>
.masonry {
  column-count: 4;
  column-gap: 1em;
}

.masonry-custom {
  column-count: 1;
  column-gap: 1em;
}

.item { /* Masonry bricks or child elements */
  background-color: #eee;
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;
  /* display: inline-block; */
}

</style>
